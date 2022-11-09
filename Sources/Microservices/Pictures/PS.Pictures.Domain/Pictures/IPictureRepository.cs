namespace PS.Pictures.Domain.Pictures;

public interface IPictureRepository
{
    Task<Picture?> GetByUidAndOwner(Guid uid, string owner, CancellationToken cancellationToken = default);

    Task Add(Picture entity, CancellationToken cancellationToken = default);

    Task Update(Picture entity, CancellationToken cancellationToken = default);

    Task<bool> IsFileNameUniqueForOwner(string owner, string fileName, CancellationToken cancellationToken = default);

    Task<int> GetSimilarNameCount(string owner, string fileName, CancellationToken cancellationToken = default);
}
