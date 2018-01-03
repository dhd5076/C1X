using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C1X.Crypto
{
    public class EcDsa
    {
        public static KeyPair GenKeyPair()
        {

            var cngKeyCreationParameters = new CngKeyCreationParameters
            {
                ExportPolicy = CngExportPolicies.AllowPlaintextExport,
                KeyUsage = CngKeyUsages.AllUsages,
                KeyCreationOptions = CngKeyCreationOptions.OverwriteExistingKey
            };

            var cngKey = CngKey.Create(CngAlgorithm.ECDsaP256, "Address", cngKeyCreationParameters);

            return new KeyPair(cngKey);
        }

        public static string Sign(string message, CngKey cngKey)
        {
            var data = Encoding.UTF8.GetBytes(message);

            using (var ecDsaCng = new ECDsaCng(cngKey))
            {
                ecDsaCng.HashAlgorithm = CngAlgorithm.Sha256;
                return Encoding.ASCII.GetString(ecDsaCng.SignData(data));
            }
        }
    }
}
