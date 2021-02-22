using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace RW7.DotNetSecurityTools.JsonWebKeys.Models
{
    public class JsonWebKeyOutput
    {
        public JsonWebKey JsonWebKey { get; set; }

        public string JsonWebKeyString { get; set; }

        public string Base64JsonWebKey => IdentityModel.Base64Url.Encode(Encoding.UTF8.GetBytes(JsonWebKeyString));

        public string RsaPublicKey { get; set; }

        public string RsaPrivateKey { get; set; }
    }
}