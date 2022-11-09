using PS.Storage.Infrastructure.Enums;

namespace PS.Storage.Infrastructure.Configurations;

internal class StorageConfiguration
{
    public string StoragePath { get; set; } = null!;

    public StorageType StorageType { get; set; }
}
