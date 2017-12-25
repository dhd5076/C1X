using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using C1X.Network;

namespace C1X.Utils
{
    class FileIO
    {
        private static string PeerListFile = "/Content/KnownPeers.lst";

        public static void LoadPeerList()
        {
            try
            {
                using (StreamReader StreamReader = new StreamReader(PeerListFile))
                {
                    while(StreamReader.Peek() >= 0)
                    {
                        string[] peerData = StreamReader.ReadLine().Split(':');
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Failed to load peer list: ", e);
            }
        }

        public static void SavePeerList(PeerNetwork peerNetwork)
        {
            try
            {
                using (StreamWriter StreamWriter = new StreamWriter(PeerListFile))
                {
                    foreach(Peer peer in C1XGame.PeerNetwork.ConnectedPeers)
                    {
                        //StreamWriter.WriteLine(peer.TcpClient.);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to save peer list: ", e);
            }
        }
    }
}
