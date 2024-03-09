using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

        public string JsonWebKeyString { 
            get
            {
                var contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };

                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore,
                };

                return JsonConvert.SerializeObject(JsonWebKey, serializerSettings);
            }
        }

        public string Base64JsonWebKey => IdentityModel.Base64Url.Encode(Encoding.UTF8.GetBytes(JsonWebKeyString));

        public string RsaPublicKey { get; }

        public string RsaPrivateKey { get; }
    }
}