using Microsoft.Extensions.DependencyInjection;

namespace Pic.Logic.DI;
public static class LogicModule
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<INameGenerationService, NameGenerationService>();

        services.AddMediatR(typeof(AddPhotoCommandHandler));
    }
}
