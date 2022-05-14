using System.Linq;
using System.Threading;
using Pic.Data.Models;

namespace Pic.Data.Repositories;

internal class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
{
    public Task<PhotoPathParts?> GetPathParts(int photoId, CancellationToken cancellationToken = default)
    {
        return Context
            .AsNoTracking()
            .OnlyActive()
            .Where(p => p.Id == photoId)
            .Select(p => new PhotoPathParts(p.PhotoAlbum.DirectoryName, p.FileName))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
