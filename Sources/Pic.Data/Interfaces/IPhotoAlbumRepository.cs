namespace Pic.Data.Interfaces;

public interface IPhotoAlbumRepository : IGenericRepository<PhotoAlbum>
{
    IAsyncEnumerable<PhotoAlbum> GetPhotoAlbums();

    IAsyncEnumerable<PhotoAlbum> FindAlbums(IEnumerable<int> photoAlbumIds);

    IAsyncEnumerable<PhotoAlbum> FindAlbumsMarkedAsDeleted();

    IAsyncEnumerable<PhotoAlbum> FindAlbumsMarkedAsDeleted(IEnumerable<int> photoAlbumIds);

    Task<PhotoAlbum?> FindUsablePhotoAlbum(int photoAlbumId, CancellationToken cancellationToken = default);
}
