using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using System.Text;

namespace RW7.DotNetSecurityTools.JsonWebKeys.Models
{
    public class JsonWebKeyOutput
    {
        public JsonWebKeyOutput(JsonWebKey jsonWebKey, string rsaPublicKey, string rsaPrivateKey)
        {
            JsonWebKey = jsonWebKey;
            RsaPublicKey = rsaPublicKey;
            RsaPrivateKey = rsaPrivateKey;
        }

        public JsonWebKey JsonWebKey { get; }

        public string JsonWebKeyString => JsonConvert.SerializeObject(JsonWebKey, Formatting.Indented);

        public string Base64JsonWebKey => IdentityModel.Base64Url.Encode(Encoding.UTF8.GetBytes(JsonWebKeyString));

        public string RsaPublicKey { get; }

        public string RsaPrivateKey { get; }
    }
}