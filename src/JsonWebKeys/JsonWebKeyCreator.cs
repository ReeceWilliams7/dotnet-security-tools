using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using RW7.DotNetSecurityTools.JsonWebKeys.Models;
using RW7.DotNetSecurityTools.RsaSecurityKeys;
using RW7.DotNetSecurityTools.RsaSecurityKeys.Extensions;

namespace RW7.DotNetSecurityTools.JsonWebKeys
{
    public class JsonWebKeyCreator : IJsonWebKeyCreator
    {
        private readonly IRsaSecurityKeyCreator _rsaSecurityKeyCreator;

        public JsonWebKeyCreator() => new JsonWebKeyCreator(new RsaSecurityKeyCreator());

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

            output.JsonWebKey = jwk;

            var jwkJson = JsonConvert.SerializeObject(jwk, Formatting.Indented);

            output.RsaPublicKey = rsaPublicKey;
            output.RsaPrivateKey = rsaPrivateKey;
            output.JsonWebKeyString = jwkJson;

            return output;
        }
    }
}