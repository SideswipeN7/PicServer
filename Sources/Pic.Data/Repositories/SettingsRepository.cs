using Pic.Data.Common;

namespace Pic.Data.Repositories;

internal class SettingsRepository : GenericRepository<Setting>, ISettingsRepository
{
    public Task<string?> FindSettingAsync(string settingKey, CancellationToken cancellationToken = default)
        => Context.Where(s => s.Key == settingKey)
                .Select(s => s.Value)
                .FirstOrDefaultAsync(cancellationToken);
}
