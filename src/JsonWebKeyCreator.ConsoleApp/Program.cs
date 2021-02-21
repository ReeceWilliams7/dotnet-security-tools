using System;
using System.Threading.Tasks;

using CommandLine;
using CommandLine.Text;

using Microsoft.Extensions.DependencyInjection;

using RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.DependencyInjection;

using Serilog;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                         .MinimumLevel.Information()
                         .WriteTo.Console()
                         .CreateLogger();

            var serviceProvider = BuildServiceProvider();

            var parser = BuildParser();

            Log.Logger.Information("Parsing command line options....");
            var parsedArguments = parser.ParseArguments<Options>(args);
            Log.Logger.Information("Finished parsing command line options....");

            await parsedArguments.WithParsedAsync(
                async options =>
                {
                    await CreateJsonWebKey(options, serviceProvider);
                });

            await parsedArguments.WithNotParsedAsync(
                async errors =>
                {
                    DisplayHelp(parsedArguments);
                    await Task.FromResult(0);
                });

            Console.Read();
        }

        private static ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddJsonWebKeyCreatorServices();

            return services.BuildServiceProvider();
        }

        private static Parser BuildParser()
        {
            return new Parser(with =>
            {
                with.CaseInsensitiveEnumValues = true;
                with.IgnoreUnknownArguments = true;
                with.AutoHelp = true;
                with.AutoVersion = true;
                with.EnableDashDash = true;
                with.CaseSensitive = false;
            });
        }

        private static async Task CreateJsonWebKey(Options options, IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var processor = scope.ServiceProvider.GetService<IJsonWebKeyCreationProcessor>();

            await processor.ProcessAsync(options);

            Log.Logger.Information("JsonWebKey creation complete");
        }

        private static void DisplayHelp<T>(ParserResult<T> result)
        {
            var helpText = HelpText.AutoBuild(
                result, h =>
                {
                    h.AdditionalNewLineAfterOption = true;
                    return HelpText.DefaultParsingErrorsHandler(result, h);
                },
                e => e);

            Console.WriteLine(helpText);
        }
    }
}