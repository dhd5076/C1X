using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using C1X.Crypto;
using C1X.Game;

namespace C1X
{
    internal class Utils
    {
        private const string PeerListFile = "Content/KnownPeers.lst";

        public static void LoadPeerList()
        {
            try
            {
                using (var streamReader = new StreamReader(PeerListFile))
                {
                    while(streamReader.Peek() >= 0)
                    {
                        try
                        {
                            var peerData = streamReader.ReadLine()?.Split(':');
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Failed to read data from player", e);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Failed to load peer list: ", e);
            }
        }

        public static void SavePeerList()
        {
            try
            {
                using (var streamWriter = new StreamWriter(PeerListFile))
                {
                    foreach(var peer in C1XGame.NodeNetwork.ConnectedNodes)
                    {
                        streamWriter.WriteLine("{0}|{1}|{2}", peer.IpAddress, KeyPair.ConvertToBase64(peer.KeyPair.PublicKey), DateTime.Now);
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
