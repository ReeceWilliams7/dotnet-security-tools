using System.Security.Cryptography;

using IdentityModel;

using Microsoft.IdentityModel.Tokens;

namespace SecurityKeys
{
    internal static class RsaSecurityKeyHelper
    {
        internal static RsaSecurityKey CreateRsaSecurityKey()
        {
            return new RsaSecurityKey(RSA.Create())
            {
                KeyId = CryptoRandom.CreateUniqueId(16, CryptoRandom.OutputFormat.Hex)
            };
        }
    }
}