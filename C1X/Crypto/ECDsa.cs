using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C1X.Crypto
{
    public class Aes256
    {
        public static RSACryptoServiceProvider RsaCryptoServiceProvider;

        public static void Init()
        {
            RsaCryptoServiceProvider = new RSACryptoServiceProvider(256);
        }

        public static string GenKeyPair()
        {

                return RsaCryptoServiceProvider.ToXmlString(true);
        }

        public static string Encrypt(byte[] data, string keyPair)
        {
            return Encoding.UTF8.GetString(RsaCryptoServiceProvider.Encrypt(data, false));
        }

        public static string Decrypt(byte[] data, string keyPair)
        {
            return Encoding.UTF8.GetString(RsaCryptoServiceProvider.Decrypt(data, false));
        }
    }
}
