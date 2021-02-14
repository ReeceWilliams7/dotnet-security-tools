namespace SecurityKeys.Models
{
    public class JsonWebKeyOutput
    {
        public string JsonWebKey { get; set; }

        public string RsaPublicKey { get; set; }

        public string RsaPrivateKey { get; set; }
    }
}