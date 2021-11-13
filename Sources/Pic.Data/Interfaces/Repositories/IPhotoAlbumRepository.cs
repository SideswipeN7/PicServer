using Pic.Data.Entities;
using Pic.Data.Models;

namespace Pic.Data.Interfaces.Repositories;

public interface IPhotoAlbumRepository : IGenericRepository<PhotoAlbum>
{
    IAsyncEnumerable<AlbumInfo> GetPhotoAlbumsInfosAsync();

    IAsyncEnumerable<PhotoAlbum> FindAlbums(IEnumerable<int> photoAlbumIds);

    IAsyncEnumerable<PhotoAlbum> FindAlbumsMarkedAsDeleted();

    IAsyncEnumerable<PhotoAlbum> FindAlbumsMarkedAsDeleted(IEnumerable<int> photoAlbumIds);
}
