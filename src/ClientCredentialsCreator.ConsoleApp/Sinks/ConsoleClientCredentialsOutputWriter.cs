using System;
using System.Threading.Tasks;

using RW7.DotNetSecurityTools.ClientCredentials;
using RW7.DotNetSecurityTools.Core;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.Sinks
{
    public class ConsoleClientCredentialsOutputWriter : IClientCredentialsOutputWriter
    {
        private readonly Action<string> _outputAction;

        public ConsoleClientCredentialsOutputWriter()
        {
            _outputAction = Console.WriteLine;
        }

        public string OutputType => Enum.GetName(typeof(OutputType), Core.OutputType.Console);

        public bool CanWrite(string outputType)
        {
            return string.Equals(outputType, OutputType, StringComparison.InvariantCultureIgnoreCase);
        }


        public async Task WriteAsync(ClientCredentialsOutput output)
        {
            WriteOutputs(output);

            await Task.CompletedTask;
        }

        private void WriteOutputs(ClientCredentialsOutput output)
        {
            _outputAction(string.Empty);

            WriteSectionDivider();

            WriteSection("Client Id", output.ClientId);

            WriteSectionDivider();

            WriteSection("Client Secret", output.ClientSecret);

            WriteSectionDivider();
        }

        private void WriteSection(string sectionTitle, string sectionValue)
        {
            _outputAction($"{sectionTitle}: {sectionValue}");
        }

        private void WriteSectionDivider()
        {
            _outputAction(string.Empty);
            _outputAction("-------------------------------------------");
            _outputAction(string.Empty);
        }
    }
}