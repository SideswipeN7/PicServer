namespace Pic.Core.Infrastructure.Interfaces.Repositories;

public interface IPhotoAlbumRepository : IGenericRepository<PhotoAlbum>
{
    IAsyncEnumerable<AlbumInfo> GetPhotoAlbumsInfos();

    IAsyncEnumerable<PhotoAlbum> FindAlbums(IEnumerable<int> photoAlbumIds);

    IAsyncEnumerable<PhotoAlbum> FindAlbumsMarkedAsDeleted();

    IAsyncEnumerable<PhotoAlbum> FindAlbumsMarkedAsDeleted(IEnumerable<int> photoAlbumIds);

    Task<AlbumInfo?> GetSinglePhotoAlbumsInfo(int photoAlbumId, CancellationToken cancellationToken = default);
}
