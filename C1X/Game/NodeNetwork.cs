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
        public TcpListener TcpListener { get; private set; }
        public List<Node> ConnectedPeers { get; private set; }

        public NodeNetwork()
        {
            TcpListener = new TcpListener(IPAddress.Any, 8090);
            ConnectedPeers = new List<Node>();
            TcpListener.Start();

            var connectionHandlerThread = new Thread(IncomingConnectionHandler);
            connectionHandlerThread.Start();
        }

        private void IncomingConnectionHandler()
        {
            while (true)
            {
                var tcpClient = TcpListener.AcceptTcpClient();
                Console.WriteLine("Client Connected!");
                ConnectedPeers.Add(new Node(tcpClient));
            }
        }

        public void Broadcast(string message)
        {
            foreach (var peer in ConnectedPeers)
            {
                peer.Send(message);
            }
        }
    }
}
