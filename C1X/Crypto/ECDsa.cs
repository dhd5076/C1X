using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C1X.Crypto
{
    public class ECDsa
    {
        public static ECDsaCng EcDsa;

        public static void Init()
        {
            EcDsa = new ECDsaCng();
            EcDsa.HashAlgorithm = CngAlgorithm.Sha256;
        }

        public static ECDsaCng GenKeyPair()
        {

            return EcDsa;
        }

        public static string Sign(string message, ECDsaCng Ec)
        {
            return 
        }
    }
}
