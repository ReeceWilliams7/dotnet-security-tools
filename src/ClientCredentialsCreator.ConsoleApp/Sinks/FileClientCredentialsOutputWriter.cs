using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using RW7.DotNetSecurityTools.ClientCredentials;
using RW7.DotNetSecurityTools.ClientCredentialsGenerator.ConsoleApp;
using RW7.DotNetSecurityTools.Core;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.Sinks
{
    public class FileClientCredentialsOutputWriter : IClientCredentialsOutputWriter
    {
        private const string FileName = "client_credentials.txt";

        private readonly ILogger<FileClientCredentialsOutputWriter> _logger;

        private readonly Options _options;

        public FileClientCredentialsOutputWriter(ILogger<FileClientCredentialsOutputWriter> logger, Options options)
        {
            _logger = logger;
            _options = options;
        }

        public string OutputType => Enum.GetName(typeof(OutputType), Core.OutputType.File);

        public bool CanWrite(string outputType)
        {
            return string.Equals(outputType, OutputType, StringComparison.InvariantCultureIgnoreCase);
        }

        public async Task WriteAsync(ClientCredentialsOutput output)
        {
            if (!Directory.Exists(_options.Directory))
            {
                Directory.CreateDirectory(_options.Directory);
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Client Id:");
            stringBuilder.AppendLine(output.ClientId);
            stringBuilder.AppendLine("Client Secret:");
            stringBuilder.AppendLine(output.ClientSecret);

            await File.WriteAllTextAsync(Path.Combine(_options.Directory, FileName), stringBuilder.ToString());

            _logger.LogInformation($"Client Credentials details written to files in {_options.Directory}");
        }
    }
}
