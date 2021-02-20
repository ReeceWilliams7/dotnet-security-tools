using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.DependencyInjection;
using RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.Sinks;
using RW7.DotNetSecurityTools.JsonWebKeys;
using Serilog;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                         .WriteTo.Console()
                         .CreateLogger();

            var serviceProvider = BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var jsonWebKeyCreator = scope.ServiceProvider.GetService<IJsonWebKeyCreator>();
            var outputWriter = scope.ServiceProvider.GetService<IJsonWebKeyOutputWriter>();

            var output = jsonWebKeyCreator.Create();

            await outputWriter.WriteAsync(output);

            Console.Read();
        }

        private static ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddSecurityKeyServices();
            services.AddSingleton<IJsonWebKeyOutputWriter, ConsoleJsonWebKeyOutputWriter>();

            return services.BuildServiceProvider();
        }
    }
}