using Microsoft.Extensions.DependencyInjection;

namespace RW7.DotNetSecurityTools.SecurityKeys.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSecurityKeyServices(this IServiceCollection services)
        {
            services.AddSingleton<IRsaSecurityKeyCreator, RsaSecurityKeyCreator>();

            services.AddSingleton<IJsonWebKeyCreator, JsonWebKeyCreator>();

            return services;
        }
    }
}
