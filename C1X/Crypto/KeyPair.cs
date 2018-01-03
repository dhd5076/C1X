using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C1X.Crypto
{
    public class KeyPair
    {
        public byte[] PublicKey { get; private set; }
        public byte[] PrivateKey { get; private set; }
        public CngKey CngKey { get; private set; }

        public KeyPair(CngKey cngKey)
        {

            this.PublicKey = cngKey.Export(CngKeyBlobFormat.EccPublicBlob);
            this.PrivateKey = cngKey.Export(CngKeyBlobFormat.EccPrivateBlob);
            this.CngKey = cngKey;
        }

        public static string ConvertToBase64(byte[] key)
        {
            return Convert.ToBase64String(key);
        }
    }
}
