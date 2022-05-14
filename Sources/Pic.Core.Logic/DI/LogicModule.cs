using Microsoft.Extensions.DependencyInjection;
using Pic.Core.Logic.Services;

namespace Pic.Core.Logic.DI;

public static class LogicModule
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<INameGenerationService, NameGenerationService>();
    }
}
