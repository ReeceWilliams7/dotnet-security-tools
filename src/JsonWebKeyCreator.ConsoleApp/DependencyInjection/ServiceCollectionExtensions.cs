using Microsoft.Extensions.DependencyInjection;

using RW7.DotNetSecurityTools.JsonWebKeys;
using RW7.DotNetSecurityTools.RsaSecurityKeys;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSecurityKeyServices(this IServiceCollection services)
        {
            services.AddSingleton<IRsaSecurityKeyCreator, RsaSecurityKeyCreator>();

            services.AddSingleton<IJsonWebKeyCreator, JsonWebKeys.JsonWebKeyCreator>();

            return services;
        }
    }
}
