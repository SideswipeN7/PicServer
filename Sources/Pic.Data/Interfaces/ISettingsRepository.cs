namespace Pic.Data.Interfaces;

public interface ISettingsRepository
{
    Task<string?> FindSetting(string settingKey, CancellationToken cancellationToken = default);
}
