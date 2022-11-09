using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PS.Storage.Application.Interfaces;
using PS.Storage.Infrastructure.Configurations;
using PS.Storage.Infrastructure.Services;

namespace PS.Storage.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var storageConfiguration = configuration.GetSection(nameof(StorageConfiguration)).Get<StorageConfiguration>();

        services.AddSingleton(storageConfiguration);

        services.AddScoped<IFileService, LocalStorageFileService>();

        return services;
    }
}
