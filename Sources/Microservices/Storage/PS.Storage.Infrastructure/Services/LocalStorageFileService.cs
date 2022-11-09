using System.Threading;
using PS.Storage.Application.Interfaces;
using PS.Storage.Infrastructure.Configurations;

namespace PS.Storage.Infrastructure.Services;

internal class LocalStorageFileService : IFileService
{
    private readonly string storagePath;

    public LocalStorageFileService(StorageConfiguration configuration) => storagePath = configuration.StoragePath;

    public bool DeleteFile(string fileName, CancellationToken cancellationToken = default)
    {
        var path = Path.Combine(storagePath, fileName);

        var fileExists = File.Exists(path);

        if (!fileExists)
        {
            return true;
        }

        try
        {
            File.Delete(path);

            return !File.Exists(path);
        }
        catch
        {
            return false;
        }
    }

    public async Task<byte[]?> TryReadFile(string fileName, CancellationToken cancellationToken = default)
    {
        try
        {
            var path = Path.Combine(storagePath, fileName);

            var fileExists = File.Exists(path);

            if (fileExists)
            {
                return await File.ReadAllBytesAsync(path, cancellationToken);
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> TrySaveFile(byte[] fileBytes, string fileName, CancellationToken cancellationToken = default)
    {
        try
        {
            var path = Path.Combine(storagePath, fileName);

            await File.WriteAllBytesAsync(path, fileBytes, cancellationToken);

            return File.Exists(path);
        }
        catch
        {
            return false;
        }
    }
}
