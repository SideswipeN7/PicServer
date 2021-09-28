using Pic.Data.Interfaces.Repositories;
using Pic.Data.Models;

namespace Pic.Persistance.Repositories;

public class PhotoAlbumRepository : GenericRepository<PhotoAlbum>, IPhotoAlbumRepository
{
}
