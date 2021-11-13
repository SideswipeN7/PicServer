using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Pic.Migrations.Extensions;

public static class MigrationRunner
{
    public static void RunMigrations(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var provider = scope.ServiceProvider;

        var logger = provider.GetRequiredService<ILogger>();

        var context = provider.GetRequiredService<PicDbContext>();

        try
        {
            logger.LogInformation("Starting Migrations");

            context.Database.Migrate();

            logger.LogInformation("Finished Migrations");
        }
        catch (Exception ex)
        {
            logger.LogCritical(ex, "Migrations failed");

            throw;
        }
    }
}
