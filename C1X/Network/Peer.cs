using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace C1X.Network
{
    public class Peer
    {
        public TcpClient TcpClient { get; private set; }
        public IPAddress IPAddress { get; private set; }
        public NetworkStream NetworkStream { get; private set; } 

        public Peer(TcpClient tcpClient)
        {
            this.TcpClient = tcpClient;
            this.NetworkStream = tcpClient.GetStream();
            this.IPAddress = IPAddress.Parse(((IPEndPoint)TcpClient.Client.RemoteEndPoint).Address.ToString());
        }

        public void Send(string message)
        {
            //NetworkStream.Read(,);
        }
    }
}
