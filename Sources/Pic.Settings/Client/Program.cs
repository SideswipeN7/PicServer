using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Authorization;
using Pic.Settings.Client.Providers;
using Pic.Settings.Client.Services;

namespace Pic.Settings.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //Authorization
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<TokenAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<TokenAuthenticationStateProvider>());
            //Other DI
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            builder.Services.AddSingleton<Interfaces.IApiClient, Mock.ApiClientMock>();
            builder.Services.AddSingleton<AppNameProvider>();
            builder.Services.AddSingleton<VersionProvider>();
            
            builder.Services.AddScoped<UsersService>();

            
            builder.Services.AddOptions();

            await builder.Build().RunAsync();
        }
    }
}
