using System.Security.Cryptography;

using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using RW7.DotNetSecurityTools.Core;

using SecurityKeys;
using SecurityKeys.Models;

namespace RW7.DotNetSecurityTools.SecurityKeys
{
    public static class SecurityKeyCreator
    {
        public static SecurityKeyOutput CreateSecurityKey()
        {
            var output = new SecurityKeyOutput();

            var rsaSecurityKey = RsaSecurityKeyHelper.CreateRsaSecurityKey();

            var rsaPublicKeyBytes = rsaSecurityKey.Rsa.ExportRSAPublicKey();
            var rsaPublicKey = PemEncoding.Write(KeyStructure.RsaPublicKey, rsaPublicKeyBytes);

            var rsaPrivateKeyBytes = rsaSecurityKey.Rsa.ExportRSAPrivateKey();
            var rsaPrivateKey = PemEncoding.Write(KeyStructure.RsaPrivateKey, rsaPrivateKeyBytes);

            var jwk = JsonWebKeyConverter.ConvertFromRSASecurityKey(rsaSecurityKey);
            jwk.Alg = SecurityAlgorithms.RsaSha256;

            var jwkJson = JsonConvert.SerializeObject(jwk, Formatting.Indented);

            output.RsaPublicKeyString = new string(rsaPublicKey);
            output.RsaPrivateKeyString = new string(rsaPrivateKey);
            output.JsonWebKeyString = jwkJson;

            return output;
        }
    }
}
