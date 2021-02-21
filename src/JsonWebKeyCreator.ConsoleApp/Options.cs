using CommandLine;

using RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.Sinks;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp
{
    public class Options
    {
        [Option('t', "output-type", Default = OutputTypes.Console, HelpText = "The output type")]
        public OutputTypes OutputType { get; set; }
    }
}
