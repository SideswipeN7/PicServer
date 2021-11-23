using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pic.Data.Repositories;

namespace Pic.Data.DI;

public static class DataModule
{
    public static void Register(ConfigurationManager configuration, IServiceCollection services)
    {
        var connectionString = configuration.GetConnectionString("default");
        services.AddDbContext<PicDbContext>(opt => opt.UseSqlServer(connectionString));

        services.AddScoped<IPhotoAlbumRepository>(x => new PhotoAlbumRepository { DbContext = x.GetService<PicDbContext>()! });
        services.AddScoped<IPhotoRepository>(x => new PhotoRepository { DbContext = x.GetService<PicDbContext>()! });
        services.AddScoped<ISettingsRepository>(x => new SettingsRepository { DbContext = x.GetService<PicDbContext>()! });
    }
}
