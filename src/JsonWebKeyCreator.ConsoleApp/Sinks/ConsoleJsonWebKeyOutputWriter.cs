using System;
using System.Threading.Tasks;

using RW7.DotNetSecurityTools.JsonWebKeys;
using RW7.DotNetSecurityTools.JsonWebKeys.Models;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.Sinks
{
    public class ConsoleJsonWebKeyOutputWriter : IJsonWebKeyOutputWriter
    {
        private readonly Action<string> _outputAction;

        public ConsoleJsonWebKeyOutputWriter()
        {
            _outputAction = Console.WriteLine;
        }

        public string OutputType => Enum.GetName(typeof(OutputTypes), OutputTypes.Console);

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

            WriteSection("JsonWebKey", output.JsonWebKey);

            WriteSectionDivider();

            WriteSection("Base64 Encoded JsonWebKey", output.Base64JsonWebKey);

            WriteSectionDivider();

            WriteSection("RSA Private Key", output.RsaPrivateKey);

            WriteSectionDivider();

            WriteSection("RSA Public Key", output.RsaPublicKey);

            WriteSectionDivider();
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