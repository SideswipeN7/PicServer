namespace Pic.Core.Logic.PhotoAlbums.Queries;

public record GetPhotoAlbumsInfoQuery : IRequest<IEnumerable<AlbumInfo>>;

public record GetSinglePhotoAlbumInfoQuery(int Id) : IRequest<AlbumInfo?>;
