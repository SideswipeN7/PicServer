using PS.Storage.Application;
using PS.Storage.Infrastructure;

namespace PS.Storage.Api.Extensions;

public static class DependencyInjectionExtensions
{
    private static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    internal static WebApplicationBuilder AddConfigurations(this WebApplicationBuilder builder)
    {
        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
        builder.Configuration.AddJsonFile("Configurations/appsettings.json", false, false);
        builder.Configuration.AddJsonFile("Configurations/appsettings.Local.json", true, false);
        builder.Configuration.AddEnvironmentVariables();

        return builder;
    }

    internal static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddApi(builder.Configuration)
            .AddInfrastructure(builder.Configuration)
            .AddApplication();

        return builder;
    }
}
