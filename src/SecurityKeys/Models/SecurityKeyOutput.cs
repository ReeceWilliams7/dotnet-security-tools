namespace SecurityKeys.Models
{
    public class SecurityKeyOutput
    {
        public string JsonWebKeyString { get; set; }

        public string Base64EncodedJsonWebKeyString { get; set; }

        public string RsaPublicKeyString { get; set; }

        public string RsaPrivateKeyString { get; set; }
    }
}
