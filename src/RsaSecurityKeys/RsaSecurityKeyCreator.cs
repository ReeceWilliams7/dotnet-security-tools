using System.Security.Cryptography;

using IdentityModel;

using Microsoft.IdentityModel.Tokens;

namespace RW7.DotNetSecurityTools.RsaSecurityKeys
{
    public class RsaSecurityKeyCreator : IRsaSecurityKeyCreator
    {
        public RsaSecurityKey Create()
        {
            return new RsaSecurityKey(RSA.Create())
            {
                KeyId = CryptoRandom.CreateUniqueId(16, CryptoRandom.OutputFormat.Hex)
            };
        }
    }
}