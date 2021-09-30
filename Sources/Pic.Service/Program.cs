using MediatR;
using Microsoft.EntityFrameworkCore;
using Pic.Data.Interfaces.Repositories;
using Pic.Logic.Interfaces;
using Pic.Logic.Photos.Commands;
using Pic.Logic.Services;
using Pic.Persistance.Contextes;
using Pic.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add configuration files.

builder.Host
    .ConfigureHostConfiguration(hostConfiguration =>
    {
        hostConfiguration.SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureAppConfiguration((_, configurationBuilder) =>
    {
        var userSettingsPath = Environment.GetEnvironmentVariable("USER_SETTINGS");

        if (!string.IsNullOrWhiteSpace(userSettingsPath))
        {
            var path = GetSystemAppsettingsConfigPath(userSettingsPath);

            var developConfigPath = Path.Combine(path, "appsettings.json");

            configurationBuilder.AddJsonFile(developConfigPath, optional: true, reloadOnChange: true);
        }

        configurationBuilder.AddEnvironmentVariables();
    });

// Add services to the container.
RegisterDI(builder.Configuration, builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pic.Service v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


RunMigration(app.Services);

app.Run();

static string GetSystemAppsettingsConfigPath(string configDirectory)
{
    var isPathFullyQualified = Path.IsPathFullyQualified(configDirectory);

    if (isPathFullyQualified)
    {
        return configDirectory;
    }
    else
    {
        var currentDirectory = Directory.GetCurrentDirectory();

        if (configDirectory.StartsWith("\\"))
        {
            configDirectory = configDirectory.Substring(1);
        }

        return Path.Combine(currentDirectory, configDirectory);
    }
}

static void RunMigration(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var provider = scope.ServiceProvider;

    var context = provider.GetRequiredService<PicDbContext>();

    context.Database.Migrate();
}

void RegisterDI(ConfigurationManager configuration, IServiceCollection services)
{
    var connectionString = configuration.GetConnectionString("default");
    services.AddDbContext<PicDbContext>(opt => opt.UseSqlServer(connectionString));

    services.AddMediatR(typeof(AddPhotoCommandHandler));

    services.AddTransient<IFileService, FileService>();
    services.AddTransient<INameGenerationService, NameGenerationService>();

    services.AddTransient<IPhotoRepository>(x => new PhotoRepository { DbContext = x.GetService<PicDbContext>() });
    services.AddTransient<IPhotoAlbumRepository>(x => new PhotoAlbumRepository { DbContext = x.GetService<PicDbContext>() });

    services.AddControllers();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new() { Title = "Pic.Service", Version = "v1" });
    });
}
