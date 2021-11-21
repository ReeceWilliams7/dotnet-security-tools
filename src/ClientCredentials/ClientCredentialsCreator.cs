using Microsoft.Extensions.Logging;

namespace RW7.DotNetSecurityTools.ClientCredentials
{
    public class ClientCredentialsCreator : IClientCredentialsCreator
    {
        private const int DefaultClientSecretLength = 32;

        private readonly IClientIdGenerator _clientIdGenerator;

        private readonly IClientSecretGenerator _clientSecretGenerator;

        public ClientCredentialsCreator() => new ClientCredentialsCreator(new GuidClientIdGenerator(), new Base64RngCryptoClientSecretGenerator());

        public ClientCredentialsCreator(IClientIdGenerator clientIdGenerator, IClientSecretGenerator clientSecretGenerator)
        {
            _clientIdGenerator = clientIdGenerator;
            _clientSecretGenerator = clientSecretGenerator;
        }

        public ClientCredentialsOutput Create()
        {
            var clientId = _clientIdGenerator.Generate();
            var clientSecret = _clientSecretGenerator.Generate(DefaultClientSecretLength);

            return new ClientCredentialsOutput(clientId, clientSecret);
        }
    }
}