using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blazorise;
using Blazorise.Material;
using Blazorise.Icons.Material;
using Blazorise.Icons.FontAwesome;

namespace Pic.Settings
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBlazorise(options =>
            {
                options.ChangeTextOnKeyPress = true;
            })
            .AddMaterialProviders()
            .AddMaterialIcons()
            .AddFontAwesomeIcons();

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddOidcAuthentication(options =>
            {
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
                builder.Configuration.Bind("Local", options.ProviderOptions);
            });

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

            builder.RootComponents.Add<App>("app");

            var host = builder.Build();

            host.Services
              .UseMaterialProviders()
              .UseMaterialIcons()
              .UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}
