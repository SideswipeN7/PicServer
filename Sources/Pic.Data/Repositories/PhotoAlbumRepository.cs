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

    public Task<AlbumInfo?> GetSinglePhotoAlbumsInfo(int photoAlbumId, CancellationToken cancellationToken = default)
    {
        return Context
            .OnlyActive()
            .Where(pa => pa.Id == photoAlbumId)
            .MapToAlbumInfo()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public IAsyncEnumerable<AlbumInfo> GetPhotoAlbumsInfos()
    {
        return Context
            .OnlyActive()
            .MapToAlbumInfo()
            .AsAsyncEnumerable();
    }
}
