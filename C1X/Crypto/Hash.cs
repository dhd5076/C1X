using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C1X.Crypto
{
    class Hash
    {
        public static string HashString(string message)
        {
            using (var hash = SHA256.Create())
            {
                hash.ComputeHash(Encoding.ASCII.GetBytes(message));
                return Encoding.ASCII.GetString(hash.Hash);
            }
        }
    }
}
