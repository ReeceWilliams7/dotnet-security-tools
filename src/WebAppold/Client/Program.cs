using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using RW7.DotNetSecurityTools.JsonWebKeys;
using RW7.DotNetSecurityTools.RsaSecurityKeys;

namespace WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<IRsaSecurityKeyCreator, RsaSecurityKeyCreator>();

            builder.Services.AddSingleton<IJsonWebKeyCreator, JsonWebKeyCreator>();

            await builder.Build().RunAsync();
        }
    }
}