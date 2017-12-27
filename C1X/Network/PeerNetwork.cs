using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C1X.Network
{
    public class PeerNetwork
    {
        public TcpListener TcpListener { get; private set; }
        public List<Peer> ConnectedPeers { get; private set; }

        public PeerNetwork()
        {
            TcpListener = new TcpListener(IPAddress.Any, 8090);
            ConnectedPeers = new List<Peer>();
            TcpListener.Start();

            Thread connectionHandlerThread = new Thread(IncomingConnectionHandler);
            connectionHandlerThread.Start();
        }

        private void IncomingConnectionHandler()
        {
            while (true)
            {
                var tcpClient = TcpListener.AcceptTcpClient();
                Console.WriteLine("Client Connected!");
                ConnectedPeers.Add(new Peer(tcpClient));
            }
        }

        public void Broadcast(string message)
        {
            foreach (Peer peer in ConnectedPeers)
            {
                peer.Send(message);
            }
        }
    }
}
