using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.Sinks;
using RW7.DotNetSecurityTools.JsonWebKeys;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp
{
    public class JsonWebKeyCreationProcessor : IJsonWebKeyCreationProcessor
    {
        private readonly ILogger<JsonWebKeyCreationProcessor> _logger;

        private readonly IJsonWebKeyCreator _jsonWebKeyCreator;

        private readonly IEnumerable<IJsonWebKeyOutputWriter> _outputWriters;

        public JsonWebKeyCreationProcessor(
            ILogger<JsonWebKeyCreationProcessor> logger,
            IJsonWebKeyCreator jsonWebKeyCreator,
            IEnumerable<IJsonWebKeyOutputWriter> outputWriters)
        {
            _logger = logger;
            _jsonWebKeyCreator = jsonWebKeyCreator;
            _outputWriters = outputWriters;
        }

        public async Task ProcessAsync(Options options)
        {
            _logger.LogInformation("Creating JsonWebKey....");
            var output = _jsonWebKeyCreator.Create();
            _logger.LogInformation("Successfully created JsonWebKey....");


            _logger.LogInformation($"Looking for output writers for the JsonWebKey, of the requested type \"{options.OutputType.ToString()}\"");
            foreach (var outputWriter in _outputWriters)
            {
                if (outputWriter.CanWrite(Enum.GetName(typeof(OutputTypes), options.OutputType)))
                {
                    _logger.LogInformation($"Found an output writer matching the requested type \"{options.OutputType.ToString()}\" - {outputWriter.GetType().Name}");
                    await outputWriter.WriteAsync(output);
                }
            }
        }
    }
}