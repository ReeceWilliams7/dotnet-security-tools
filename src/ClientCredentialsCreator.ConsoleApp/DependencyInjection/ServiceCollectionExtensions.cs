using Microsoft.Extensions.DependencyInjection;

using RW7.DotNetSecurityTools.ClientCredentials;
using RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.Sinks;

using Serilog;

namespace RW7.DotNetSecurityTools.ClientCredentialsGenerator.ConsoleApp.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddClientCredentialsCreatorServices(this IServiceCollection services)
        {
            services.AddLogging(builder => builder.AddSerilog());

            services.AddSingleton<IClientIdGenerator, GuidClientIdGenerator>();
            services.AddSingleton<IClientSecretGenerator, Base64RngCryptoClientSecretGenerator>();

            services.AddSingleton<IClientCredentialsCreator, ClientCredentialsCreator>();

            services.AddSingleton<IClientCredentialsCreationProcessor, ClientCredentialsCreationProcessor>();

            services.AddSingleton<IClientCredentialsOutputWriter, ConsoleClientCredentialsOutputWriter>();
            services.AddSingleton<IClientCredentialsOutputWriter, FileClientCredentialsOutputWriter>();

            return services;
        }
    }
}
