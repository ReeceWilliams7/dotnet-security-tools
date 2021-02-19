using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using RW7.DotNetSecurityTools.SecurityKeys.Extensions;
using RW7.DotNetSecurityTools.SecurityKeys.Models;

namespace RW7.DotNetSecurityTools.SecurityKeys
{
    public class JsonWebKeyCreator : IJsonWebKeyCreator
    {
        private readonly IRsaSecurityKeyCreator _rsaSecurityKeyCreator;

        public JsonWebKeyCreator(IRsaSecurityKeyCreator rsaSecurityKeyCreator)
        {
            _rsaSecurityKeyCreator = rsaSecurityKeyCreator;
        }

        public JsonWebKeyOutput Create()
        {
            var output = new JsonWebKeyOutput();

            var rsaSecurityKey = _rsaSecurityKeyCreator.Create();

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