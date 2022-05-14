using Pic.Data.Models;

namespace Pic.Data.Interfaces;

public interface IPhotoRepository : IGenericRepository<Photo>
{
    Task<PhotoPathParts?> GetPathParts(int photoId, CancellationToken cancellationToken = default);
}
