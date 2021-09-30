namespace Pic.Data.Interfaces.Repositories;

public interface ISettingsRepository
{
    Task<string> FindSetting(string settingKey);
}
