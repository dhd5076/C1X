using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace C1X.Network
{
    public class PeerNetwork
    {
        public TcpListener TcpListener { get; private set; }


        public PeerNetwork()
        {
            TcpListener = new TcpListener(IPAddress.Any, 8090);

            TcpListener.Start();
        }

        private void AcceptConnections()
        {
            while (true)
            {

            }
        }
    }
}
