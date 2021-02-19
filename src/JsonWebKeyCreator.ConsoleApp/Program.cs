using System;

using Microsoft.Extensions.DependencyInjection;

using RW7.DotNetSecurityTools.SecurityKeys;
using RW7.DotNetSecurityTools.SecurityKeys.Extensions;
using RW7.DotNetSecurityTools.SecurityKeys.Models;

using Serilog;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                         .WriteTo.Console()
                         .CreateLogger();

            var services = new ServiceCollection();
            services.AddSecurityKeyServices();

            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var jsonWebKeyCreator = scope.ServiceProvider.GetService<IJsonWebKeyCreator>();

            var output = jsonWebKeyCreator.Create();

            WriteOutputs(output);

            Console.Read();
        }

        private static void WriteOutputs(JsonWebKeyOutput output)
        {
            WriteSection("JsonWebKey", output.JsonWebKey);

            WriteSectionDivider();

            WriteSection("Base64 Encoded JsonWebKey", output.Base64JsonWebKey);

            WriteSectionDivider();

            WriteSection("RSA Private Key", output.RsaPrivateKey);

            WriteSectionDivider();

            WriteSection("RSA Public Key", output.RsaPublicKey);
        }

        private static void WriteSection(string sectionTitle, string sectionValue)
        {
            WriteSectionBorder();
            Console.WriteLine($"{sectionTitle}:");
            Console.WriteLine();
            Console.WriteLine(sectionValue);
            Console.WriteLine();
            WriteSectionBorder();
        }

        private static void WriteSectionBorder()
        {
            Console.WriteLine("******************************************");
        }

        private static void WriteSectionDivider()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
        }
    }
}
