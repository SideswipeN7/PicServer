namespace Pic.Logic.PhotoAlbums.Commands;

public class MarkPhotoAlbumsAsDeletedCommandHandler : IRequestHandler<MarkPhotoAlbumsAsDeletedCommand>
{
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public MarkPhotoAlbumsAsDeletedCommandHandler(IPhotoAlbumRepository photoAlbumRepository) => this.photoAlbumRepository = photoAlbumRepository;

    public async Task<Unit> Handle(MarkPhotoAlbumsAsDeletedCommand request, CancellationToken cancellationToken)
    {
        var photoAlbums = photoAlbumRepository.FindAlbums(request.PhotoAlbumIds);

        await photoAlbums.ForEachAsync(pa => pa.MarkAsDeleted(), cancellationToken);

        await photoAlbumRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
