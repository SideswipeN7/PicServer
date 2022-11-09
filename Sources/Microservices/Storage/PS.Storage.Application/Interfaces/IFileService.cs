namespace PS.Storage.Application.Interfaces;

public interface IFileService
{
    Task<bool> TrySaveFile(byte[] fileBytes, string fileName, CancellationToken cancellationToken = default);

    Task<byte[]?> TryReadFile(string fileName, CancellationToken cancellationToken = default);

    bool DeleteFile(string fileName, CancellationToken cancellationToken = default);
}
