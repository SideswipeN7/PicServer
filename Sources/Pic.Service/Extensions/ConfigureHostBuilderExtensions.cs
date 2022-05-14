namespace Pic.Service.Extensions;

public static class ConfigureHostBuilderExtensions
{
    private const string ConfigurationFileName = "appsettings";
    private const string ConfigurationFileExtension = "json";

    public static ConfigureHostBuilder AddConfigurationFiles(this ConfigureHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureHostConfiguration(hostConfiguration =>
        {
            hostConfiguration.SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile($"{ConfigurationFileName}.{ConfigurationFileExtension}", optional: false, reloadOnChange: true);
#if DEBUG
            hostConfiguration.SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile($"{ConfigurationFileName}.Local.{ConfigurationFileExtension}", optional: true, reloadOnChange: true);
        });
#else
       hostConfiguration.SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile($"{ConfigurationFileName}.Development.{ConfigurationFileExtension}", optional: true, reloadOnChange: true);
        });
#endif

        return hostBuilder;
    }
}
