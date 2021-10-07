namespace Pic.Persistance.Repositories;

public class SettingsRepository : GenericRepository<Setting>, ISettingsRepository
{
    public Task<string> FindSettingAsync(string settingKey, CancellationToken cancellationToken = default)
        => Context
                .Where(s => s.Key == settingKey)
                .Select(s => s.Value)
                .FirstOrDefaultAsync(cancellationToken);
}
