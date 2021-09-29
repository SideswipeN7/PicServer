using Pic.Data.Interfaces.Repositories;
using Pic.Logic.Photos.Commands;

namespace Pic.Logic.PhotoAlbums.Commands;

public class MarkPhotoAlbumAsDeletedCommandHandler : IRequestHandler<MarkPhotoAlbumAsDeletedCommand>
{
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public MarkPhotoAlbumAsDeletedCommandHandler(IPhotoAlbumRepository photoAlbumRepository) => this.photoAlbumRepository = photoAlbumRepository;

    public async Task<Unit> Handle(MarkPhotoAlbumAsDeletedCommand request, CancellationToken cancellationToken)
    {
        var photoAlbum = await photoAlbumRepository.FindAsync(request.PhotoAlbumId, cancellationToken);

        if (photoAlbum is null)
        {
            // TODO: Implement Exception
            throw new ArgumentException(string.Empty);
        }

        photoAlbum.MarkAsDeleted();

        await photoAlbumRepository.UpdateAsync(photoAlbum, cancellationToken);

        return Unit.Value;
    }
}
