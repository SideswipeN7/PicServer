using Pic.Data.Common;

namespace Pic.Data.Repositories;

internal class PhotoAlbumRepository : GenericRepository<PhotoAlbum>, IPhotoAlbumRepository
{
    public IAsyncEnumerable<PhotoAlbum> FindAlbums(IEnumerable<int> photoAlbumIds)
    {
        return Context
            .OnlyActive()
            .Where(pa => photoAlbumIds.Contains(pa.Id))
            .AsAsyncEnumerable();
    }

    public IAsyncEnumerable<PhotoAlbum> FindAlbumsMarkedAsDeleted()
    {
        return Context
            .Where(pa => pa.IsDeleted)
            .AsAsyncEnumerable();
    }

    public IAsyncEnumerable<PhotoAlbum> FindAlbumsMarkedAsDeleted(IEnumerable<int> photoAlbumIds)
    {
        return Context
             .Where(pa => pa.IsDeleted && photoAlbumIds.Contains(pa.Id))
             .AsAsyncEnumerable();
    }

    public IAsyncEnumerable<AlbumInfo> GetPhotoAlbumsInfosAsync()
    {
        return Context
            .OnlyActive()
            .Select(pa => new AlbumInfo
            {
                Id = pa.Id,
                Title = pa.Title,
                Thumbnail = pa.Thumbnail ?? Array.Empty<byte>(),
                PhotosCount = pa.Photos.Count,
            }).AsAsyncEnumerable();
    }
}
