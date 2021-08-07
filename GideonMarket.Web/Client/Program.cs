using Blazored.LocalStorage;
using GideonMarket.Web.Client.Application;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GideonMarket.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Task.Delay(500);
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<TokenService>();
            builder.Services.AddTransient<AuthService>();
            builder.Services.AddScoped<IAppService, AppService>();

            builder.Services.AddScoped<AuthenticationStateProvider, LocalStorageAuthProvider>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();


            #region Radzen
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();
            #endregion


            await builder.Build().RunAsync();
        }
    }
}
