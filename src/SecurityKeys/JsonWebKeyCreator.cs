using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using SecurityKeys;
using SecurityKeys.Extensions;
using SecurityKeys.Models;

namespace RW7.DotNetSecurityTools.SecurityKeys
{
    public static class JsonWebKeyCreator
    {
        public static JsonWebKeyOutput CreateSecurityKey()
        {
            var output = new JsonWebKeyOutput();

            var rsaSecurityKey = RsaSecurityKeyHelper.CreateRsaSecurityKey();

            var rsaPublicKey = rsaSecurityKey.Rsa.ExportPemEncodedPublicKey();
            var rsaPrivateKey = rsaSecurityKey.Rsa.ExportPemEncodedPrivateKey();

            var jwk = JsonWebKeyConverter.ConvertFromRSASecurityKey(rsaSecurityKey);
            jwk.Alg = SecurityAlgorithms.RsaSha256;

            var jwkJson = JsonConvert.SerializeObject(jwk, Formatting.Indented);

            output.RsaPublicKey = rsaPublicKey;
            output.RsaPrivateKey = rsaPrivateKey;
            output.JsonWebKey = jwkJson;

            return output;
        }
    }
}