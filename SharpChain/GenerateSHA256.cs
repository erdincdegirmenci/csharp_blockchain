using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SharpChain
{
   internal class GenerateSHA256
    {
        public string GetHash(string data) {
            var sha256 = new SHA256Managed();
            var hashBuilder = new StringBuilder();

            var dataBytes = System.Text.Encoding.Unicode.GetBytes(data);
            var hash = sha256.ComputeHash(dataBytes);

            foreach (var b in hash)
            {
                hashBuilder.Append($"{b:x2}");
            }
            return hashBuilder.ToString();
        }
    }
}
