using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace C1X.Network
{
    class Peer
    {
        public TcpClient TcpClient;

        public Peer(TcpClient tcpClient)
        {
            this.TcpClient = tcpClient;
        }
    }
}
