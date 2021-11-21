using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using RW7.DotNetSecurityTools.Core;
using RW7.DotNetSecurityTools.JsonWebKeys;
using RW7.DotNetSecurityTools.JsonWebKeys.Models;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.Sinks
{
    public class FileJsonWebKeyOutputWriter : IJsonWebKeyOutputWriter
    {
        private const string JsonWebKeyFileName = "JsonWebKey.jwk";

        private const string RsaPublicKeyFileName = "RsaPublicKey.pem";

        private const string RsaPrivateKeyFileName = "RsaPrivateKey.pem";

        private readonly ILogger<FileJsonWebKeyOutputWriter> _logger;

        private readonly Options _options;

        public FileJsonWebKeyOutputWriter(ILogger<FileJsonWebKeyOutputWriter> logger, Options options)
        {
            _logger = logger;
            _options = options;
        }

        public string OutputType => Enum.GetName(typeof(OutputType), Core.OutputType.File);

        public bool CanWrite(string outputType)
        {
            return string.Equals(outputType, OutputType, StringComparison.InvariantCultureIgnoreCase);
        }

        public async Task WriteAsync(JsonWebKeyOutput output)
        {
            if (!Directory.Exists(_options.Directory))
            {
                Directory.CreateDirectory(_options.Directory);
            }

            await File.WriteAllTextAsync(Path.Combine(_options.Directory, JsonWebKeyFileName), output.JsonWebKeyString);
            if (_options.OutputBase64)
            {
                await File.WriteAllTextAsync(Path.Combine(_options.Directory, JsonWebKeyFileName), output.Base64JsonWebKey);
            }
            if (_options.OutputRsaKeys)
            {
                await File.WriteAllTextAsync(Path.Combine(_options.Directory, RsaPublicKeyFileName), output.RsaPublicKey);
                await File.WriteAllTextAsync(Path.Combine(_options.Directory, RsaPrivateKeyFileName), output.RsaPrivateKey);
            }

            _logger.LogInformation($"JsonWebKey details written to files in {_options.Directory}");
        }
    }
}
