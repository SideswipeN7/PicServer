using Microsoft.AspNetCore.SpaServices.AngularCli;
using Pic.Migrations.Extensions;

namespace Pic.Service.Extensions;

public static class WebApplicationExtensions
{
    //private const string BaseUri = "http://localhost:4200";

    public static WebApplication UseClientApp(this WebApplication webApplication)
    {
        //webApplication.MapWhen(
        //    x => x.Request.Path.HasValue && !x.Request.Path.Value.StartsWith("/api"),
        //    builder => builder.UseSpa(spa =>
        //    {
        //        spa.Options.SourcePath = "..\\Pic.Client";

        //        if (webApplication.Environment.IsDevelopment())
        //        {
        //            // spa.UseAngularCliServer(npmScript: "start");
        //            spa.UseProxyToSpaDevelopmentServer(BaseUri);
        //        }
        //    }));

        return webApplication;
    }

    public static WebApplication UseMigrations(this WebApplication webApplication)
    {
        MigrationRunner.RunMigrations(webApplication.Services);

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
