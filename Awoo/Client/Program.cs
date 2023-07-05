global using Awoo.Shared;
using Awoo.Client;
using Awoo.Client.Services.TabletopSessionService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Awoo.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ITabletopSessionService, TabletopSessionService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITTRPGService, TTRPGService>();

            await builder.Build().RunAsync();
        }
    }
}