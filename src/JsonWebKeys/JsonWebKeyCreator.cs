using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using RW7.DotNetSecurityTools.JsonWebKeys.Models;
using RW7.DotNetSecurityTools.RsaSecurityKeys;
using RW7.DotNetSecurityTools.RsaSecurityKeys.Extensions;

namespace RW7.DotNetSecurityTools.JsonWebKeys
{
    public class JsonWebKeyCreator : IJsonWebKeyCreator
    {
        private readonly ILogger<JsonWebKeyCreator> _logger;

        private readonly IRsaSecurityKeyCreator _rsaSecurityKeyCreator;

        public JsonWebKeyCreator(ILogger<JsonWebKeyCreator> logger, IRsaSecurityKeyCreator rsaSecurityKeyCreator)
        {
            _logger = logger;
            _rsaSecurityKeyCreator = rsaSecurityKeyCreator;
        }

        public JsonWebKeyOutput Create()
        {
            var output = new JsonWebKeyOutput();

            _logger.LogInformation("Creating a new RsaSecurityKey to use for the JsonWebKey");
            var rsaSecurityKey = _rsaSecurityKeyCreator.Create();

            _logger.LogInformation("Getting the PEM encoded RSA Public Key");
            var rsaPublicKey = rsaSecurityKey.Rsa.ExportPemEncodedPublicKey();
            _logger.LogInformation("Getting the PEM encoded RSA Private Key");
            var rsaPrivateKey = rsaSecurityKey.Rsa.ExportPemEncodedPrivateKey();

            _logger.LogInformation("Creating the JsonWebKey from the RsaSecurityKey");
            var jwk = JsonWebKeyConverter.ConvertFromRSASecurityKey(rsaSecurityKey);
            jwk.Alg = SecurityAlgorithms.RsaSha256;

            output.JsonWebKey = jwk;

            _logger.LogInformation("Serializing the JsonWebKey");
            var jwkJson = JsonConvert.SerializeObject(jwk, Formatting.Indented);

            output.RsaPublicKey = rsaPublicKey;
            output.RsaPrivateKey = rsaPrivateKey;
            output.JsonWebKeyString = jwkJson;

            return output;
        }
    }
}