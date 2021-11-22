using Microsoft.IdentityModel.Tokens;

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
            var rsaSecurityKey = _rsaSecurityKeyCreator.Create();
            var rsaPublicKey = rsaSecurityKey.Rsa.ExportPemEncodedPublicKey();
            var rsaPrivateKey = rsaSecurityKey.Rsa.ExportPemEncodedPrivateKey();

            var jwk = JsonWebKeyConverter.ConvertFromRSASecurityKey(rsaSecurityKey);
            jwk.Alg = SecurityAlgorithms.RsaSha256;

            var output = new JsonWebKeyOutput(jwk, rsaPublicKey, rsaPrivateKey);

            return output;
        }
    }
}