using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Authentication
{
    public static class TokenCryptography
    {
        public static string sha256(string input)
        {
            var crypt = SHA256.Create();

            byte[] inputByes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = crypt.ComputeHash(inputByes);
            var result = hashBytes.ToString();

            return result;
        }
    }
}
