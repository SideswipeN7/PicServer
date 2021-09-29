using Pic.Data.Interfaces.Repositories;
using Pic.Logic.Photos.Commands;

namespace Pic.Logic.PhotoAlbums.Commands;

public class RestorePhotoAlbumsCommandHandler : IRequestHandler<RestorePhotoAlbumsCommand>
{
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public RestorePhotoAlbumsCommandHandler(IPhotoAlbumRepository photoAlbumRepository) => this.photoAlbumRepository = photoAlbumRepository;

    public async Task<Unit> Handle(RestorePhotoAlbumsCommand request, CancellationToken cancellationToken)
    {
        var photoAlbums = photoAlbumRepository.FindAlbumsMarkedAsDeleted(request.PhotoAlbumIds);

        await photoAlbums.ForEachAsync(pa => pa.MarkAsDeleted(), cancellationToken);

        await photoAlbumRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
