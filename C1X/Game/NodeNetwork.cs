using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using C1X.Game;

namespace C1X.Game
{
    public class NodeNetwork
    {
        private readonly TcpListener _tcpListener;
        public List<Node> ConnectedNodes { get; }
        public bool ListenForIncomingConnections { get; private set; }

        public NodeNetwork()
        {
            _tcpListener = new TcpListener(IPAddress.Any, 8090);
            ConnectedNodes = new List<Node>();
            _tcpListener.Start();
            ListenForIncomingConnections = true;

            var connectionHandlerThread = new Thread(IncomingConnectionHandler);
            connectionHandlerThread.Start();
        }

        private void IncomingConnectionHandler()
        {
            while (ListenForIncomingConnections)
            {
                var tcpClient = _tcpListener.AcceptTcpClient();
                Console.WriteLine("Client Connected!");
                ConnectedNodes.Add(new Node(tcpClient.Client, false));
            }
        }

        public void Broadcast(string message)
        {
            foreach (var peer in ConnectedNodes)
            {
                peer.Send(message);
            }
        }

        public void DisconnectNetwork()
        {
            ListenForIncomingConnections = false;
            foreach (var node in ConnectedNodes)
            {
                node.Socket.Disconnect(false);
            }
        }
    }
}
