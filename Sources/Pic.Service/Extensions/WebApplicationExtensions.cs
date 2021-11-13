using Microsoft.AspNetCore.SpaServices.AngularCli;
using Pic.Migrations.Extensions;

namespace Pic.Service.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseClientApp(this WebApplication webApplication)
    {
        webApplication.UseSpa(spa =>
        {
            spa.Options.SourcePath = "..\\Pic.Client";

            if (webApplication.Environment.IsDevelopment())
            {
                spa.UseAngularCliServer(npmScript: "start");
#pragma warning disable S1075 // URIs should not be hardcoded
                spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
#pragma warning restore S1075 // URIs should not be hardcoded
            }
        });

        return webApplication;
    }

    public static WebApplication RunMigrations(this WebApplication webApplication)
    {
        MigrationRunner.RunMigrations(webApplication.Services);

        return webApplication;
    }

    public static WebApplication UseSwagger(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pic.Service v1"));
        }

        return webApplication;
    }
}
