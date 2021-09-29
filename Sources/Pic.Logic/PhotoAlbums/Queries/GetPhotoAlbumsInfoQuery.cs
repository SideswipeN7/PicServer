using Pic.Data.Models;

namespace Pic.Logic.PhotoAlbums.Queries;

public record GetPhotoAlbumsInfoQuery : IRequest<IEnumerable<AlbumInfo>>;
