namespace Pic.Data.Interfaces.Repositories;

public interface ISettingsRepository
{
    Task<string> FindSettingAsync(string settingKey, CancellationToken cancellationToken = default);
}
