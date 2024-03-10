using System;
using System.Threading.Tasks;

using RW7.DotNetSecurityTools.Core;
using RW7.DotNetSecurityTools.JsonWebKeys;
using RW7.DotNetSecurityTools.JsonWebKeys.Models;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.Sinks
{
    public class ConsoleJsonWebKeyOutputWriter : IJsonWebKeyOutputWriter
    {
        private readonly Action<string> _outputAction;

        private readonly Options _options;

        public ConsoleJsonWebKeyOutputWriter(Options options)
        {
            _outputAction = Console.WriteLine;
            _options = options;
        }

        public string OutputType => Enum.GetName(typeof(OutputType), Core.OutputType.Console);

        public bool CanWrite(string outputType)
        {
            return string.Equals(outputType, OutputType, StringComparison.InvariantCultureIgnoreCase);
        }

        public async Task WriteAsync(JsonWebKeyOutput output)
        {
            WriteOutputs(output);
            await Task.CompletedTask;
        }

        private void WriteOutputs(JsonWebKeyOutput output)
        {
            _outputAction(string.Empty);

            WriteSectionDivider();

            WriteSection("JsonWebKey", output.JsonWebKeyString);

            WriteSectionDivider();

            if (_options.OutputBase64)
            {
                WriteSection("Base64 Encoded JsonWebKey", output.Base64JsonWebKey);

                WriteSectionDivider();
            }

            if (_options.OutputRsaKeys)
            {
                WriteSection("RSA Private Key", output.RsaPrivateKey);

                WriteSectionDivider();

                WriteSection("RSA Public Key", output.RsaPublicKey);

                WriteSectionDivider();
            }

            if (_options.OutputPkcs8)
            {
                WriteSection("PKCS8 Private Key", output.Pkcs8PrivateKey);

                WriteSectionDivider();
            }
        }

        private void WriteSection(string sectionTitle, string sectionValue)
        {
            _outputAction(string.Empty);
            _outputAction($"{sectionTitle}:");
            _outputAction(string.Empty);
            _outputAction(sectionValue);
            _outputAction(string.Empty);
        }

        private void WriteSectionDivider()
        {
            _outputAction(string.Empty);
            _outputAction("-------------------------------------------");
            _outputAction(string.Empty);
        }
    }
}