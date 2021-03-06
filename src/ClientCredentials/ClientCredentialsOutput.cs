namespace RW7.DotNetSecurityTools.ClientCredentials
{
    public class ClientCredentialsOutput
    {
        public ClientCredentialsOutput(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string ClientId { get; }
        
        public string ClientSecret { get; }
    }
}
