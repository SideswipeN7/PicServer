using Pic.Data.Interfaces.Repositories;
using Pic.Data.Models;

namespace Pic.Logic.PhotoAlbums.Queries;

internal class GetPhotoAlbumsInfoQueryHandler : IRequestHandler<GetPhotoAlbumsInfoQuery, IEnumerable<AlbumInfo>>
{
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public GetPhotoAlbumsInfoQueryHandler(IPhotoAlbumRepository photoAlbumRepository)
    {
        this.photoAlbumRepository = photoAlbumRepository;
    }

    public async Task<IEnumerable<AlbumInfo>> Handle(GetPhotoAlbumsInfoQuery request, CancellationToken cancellationToken)
    {
        var results = await photoAlbumRepository.GetPhotoAlbumsInfosAsync().ToListAsync(cancellationToken);

        return results;
    }
}
