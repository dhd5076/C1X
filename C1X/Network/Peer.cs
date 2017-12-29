using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using C1X.Game;

namespace C1X.Network
{
    public class Peer
    {
        public TcpClient TcpClient { get; private set; }
        public IPAddress IpAddress { get; private set; }
        public StreamWriter StreamWriter { get; private set; }
        public StreamReader StreamReader { get; private set; }
        public Node Node { get; private set; }


        public Peer(TcpClient tcpClient)
        {
            this.TcpClient = tcpClient;
            this.StreamWriter = new StreamWriter(tcpClient.GetStream());
            this.StreamReader = new StreamReader(tcpClient.GetStream());
            this.IpAddress = IPAddress.Parse(((IPEndPoint)TcpClient.Client.RemoteEndPoint).Address.ToString());
            this.Node = new Node();

            EstablishRelationship();
        }

        public void EstablishRelationship()
        {

        }

        public void Send(string message)
        {
            if (TcpClient.Connected)
            {
                Thread.Sleep(1);
                StreamWriter.WriteAsync(message);
            }
        }

        public void Recieve()
        {
            if (TcpClient.Connected)
            {
                StreamReader.Read();
            }
        }

        public void Destroy()
        {
            this.TcpClient.Close();
            C1XGame.PeerNetwork.ConnectedPeers.Remove(this);
        }
    }
}
