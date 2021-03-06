using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using RW7.DotNetSecurityTools.ClientCredentials;
using RW7.DotNetSecurityTools.Core;

namespace RW7.DotNetSecurityTools.ClientCredentialsGenerator.ConsoleApp
{
    public class ClientCredentialsCreationProcessor : IClientCredentialsCreationProcessor
    {
        private readonly ILogger<ClientCredentialsCreationProcessor> _logger;

        private readonly IClientCredentialsCreator _clientCredentialsCreator;

        private readonly IEnumerable<IClientCredentialsOutputWriter> _outputWriters;

        public ClientCredentialsCreationProcessor(
            ILogger<ClientCredentialsCreationProcessor> logger,
            IClientCredentialsCreator clientCredentialsCreator,
            IEnumerable<IClientCredentialsOutputWriter> outputWriters)
        {
            _logger = logger;
            _clientCredentialsCreator = clientCredentialsCreator;
            _outputWriters = outputWriters;
        }

        public async Task ProcessAsync(Options options)
        {
            _logger.LogInformation("Creating Client Credentials....");
            var output = _clientCredentialsCreator.Create();
            _logger.LogInformation("Successfully created Client Credentials....");

            foreach (var outputType in options.OutputTypes)
            {
                _logger.LogInformation($"Looking for output writers for the Client Credentials, of the requested type \"{outputType}\"");
                foreach (var outputWriter in _outputWriters)
                {
                    if (outputWriter.CanWrite(Enum.GetName(typeof(OutputType), outputType)))
                    {
                        _logger.LogInformation($"Found an output writer matching the requested type \"{outputType}\" - {outputWriter.GetType().Name}");
                        await outputWriter.WriteAsync(output);
                    }
                }
            }
        }
    }
}
