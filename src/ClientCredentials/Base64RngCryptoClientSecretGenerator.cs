using System;
using System.Security.Cryptography;

namespace RW7.DotNetSecurityTools.ClientCredentials
{
    public class Base64RngCryptoClientSecretGenerator : IClientSecretGenerator
    {
        public string Generate(int length)
        {
            using var rng = new RNGCryptoServiceProvider();

            var buffer = new byte[length];
            rng.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }
    }
}