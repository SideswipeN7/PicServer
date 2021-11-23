using Microsoft.AspNetCore.SpaServices.AngularCli;

//using Pic.Data.Migrations.Extensions;

namespace Pic.Service.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseClientApp(this WebApplication webApplication)
    {
        webApplication.MapWhen(
            x => x.Request.Path.HasValue && !x.Request.Path.Value.StartsWith("/api"),
            builder => builder.UseSpa(spa =>
            {
                spa.Options.SourcePath = "..\\Pic.Client";

                if (webApplication.Environment.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            }));

        return webApplication;
    }

    public static WebApplication RunMigrations(this WebApplication webApplication)
    {
        //MigrationRunner.RunMigrations(webApplication.Services);

        return webApplication;
    }

    public static WebApplication UseConfiguredSwagger(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pic.Service v1"));
        }

        return webApplication;
    }
}
