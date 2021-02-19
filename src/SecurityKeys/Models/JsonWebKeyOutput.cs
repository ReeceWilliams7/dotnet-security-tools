using System.Text;

namespace RW7.DotNetSecurityTools.SecurityKeys.Models
{
    public class JsonWebKeyOutput
    {
        public string JsonWebKey { get; set; }

        public string Base64JsonWebKey => IdentityModel.Base64Url.Encode(Encoding.UTF8.GetBytes(JsonWebKey));

        public string RsaPublicKey { get; set; }

        public string RsaPrivateKey { get; set; }
    }
}