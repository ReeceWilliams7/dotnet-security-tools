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
            _outputAction = System.Console.WriteLine;
        }

        public async Task WriteAsync(JsonWebKeyOutput output)
        {
            WriteOutputs(output);
            await Task.CompletedTask;
        }

        private void WriteOutputs(JsonWebKeyOutput output)
        {
            WriteSection("JsonWebKey", output.JsonWebKey);

            WriteSectionDivider();

            WriteSection("Base64 Encoded JsonWebKey", output.Base64JsonWebKey);

            WriteSectionDivider();

            WriteSection("RSA Private Key", output.RsaPrivateKey);

            WriteSectionDivider();

            WriteSection("RSA Public Key", output.RsaPublicKey);
        }

        private void WriteSection(string sectionTitle, string sectionValue)
        {
            WriteSectionBorder();
            _outputAction($"{sectionTitle}:");
            _outputAction(string.Empty);
            _outputAction(sectionValue);
            _outputAction(string.Empty);
            WriteSectionBorder();
        }

        private void WriteSectionBorder()
        {
            _outputAction("******************************************");
        }

        private void WriteSectionDivider()
        {
            _outputAction(string.Empty);
            _outputAction("-------------------------------------------");
            _outputAction(string.Empty);
        }
    }
}