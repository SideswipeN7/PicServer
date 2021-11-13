namespace Pic.Service.Extensions;

public static class ConfigureHostBuilderExtensions
{
    private const string ConfigurationFileName = "appsettings.json";

    public static ConfigureHostBuilder AddConfigurationFiles(this ConfigureHostBuilder hostBuilder)
    {
        AddBaseConfigurationFile(hostBuilder);
        AddUserConfigurationFile(hostBuilder);

        return hostBuilder;
    }

    private static void AddBaseConfigurationFile(ConfigureHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureHostConfiguration(hostConfiguration =>
        {
            hostConfiguration.SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile(ConfigurationFileName, optional: false, reloadOnChange: true);
        });
    }

    private static void AddUserConfigurationFile(ConfigureHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureAppConfiguration((_, configurationBuilder) =>
        {
            var userSettingsPath = Environment.GetEnvironmentVariable("USER_SETTINGS");

            if (!string.IsNullOrWhiteSpace(userSettingsPath))
            {
                var path = GetSystemAppsettingsConfigPath(userSettingsPath);

                var developConfigPath = Path.Combine(path, ConfigurationFileName);

                configurationBuilder.AddJsonFile(developConfigPath, optional: true, reloadOnChange: true);
            }

            configurationBuilder.AddEnvironmentVariables();
        });
    }

    private static string GetSystemAppsettingsConfigPath(string configDirectory)
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
}
