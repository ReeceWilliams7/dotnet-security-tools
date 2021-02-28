using Microsoft.Extensions.DependencyInjection;

using RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.Sinks;
using RW7.DotNetSecurityTools.JsonWebKeys;
using RW7.DotNetSecurityTools.RsaSecurityKeys;

using Serilog;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddJsonWebKeyCreatorServices(this IServiceCollection services)
        {
            services.AddLogging(builder => builder.AddSerilog());

            services.AddSingleton<IRsaSecurityKeyCreator, RsaSecurityKeyCreator>();

            services.AddSingleton<IJsonWebKeyCreator, JsonWebKeys.JsonWebKeyCreator>();

            services.AddSingleton<IJsonWebKeyCreationProcessor, JsonWebKeyCreationProcessor>();

            services.AddSingleton<IJsonWebKeyOutputWriter, ConsoleJsonWebKeyOutputWriter>();
            services.AddSingleton<IJsonWebKeyOutputWriter, FileJsonWebKeyOutputWriter>();

            return services;
        }
    }
}
