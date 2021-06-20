using Blazored.LocalStorage;
using GideonMarket.Web.Client.Application;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GideonMarket.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDQzNzkwQDMxMzkyZTMxMmUzMEhDeDdONXZEUGp3aFU1NGw4NHJETVhZc3JVUElxVXJWTzlFeW14Ry8vNWs9");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<TokenService>();
            builder.Services.AddTransient<AuthService>();
            builder.Services.AddScoped<IAppService, AppService>();

            builder.Services.AddScoped<AuthenticationStateProvider, LocalStorageAuthProvider>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}
