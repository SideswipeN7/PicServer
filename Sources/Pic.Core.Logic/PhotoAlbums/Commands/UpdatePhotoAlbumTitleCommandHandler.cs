namespace Pic.Core.Logic.PhotoAlbums.Commands;

public class UpdatePhotoAlbumTitleCommandHandler : IRequestHandler<UpdatePhotoAlbumTitleCommand>
{
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public UpdatePhotoAlbumTitleCommandHandler(IPhotoAlbumRepository photoAlbumRepository) => this.photoAlbumRepository = photoAlbumRepository;

    public async Task<Unit> Handle(UpdatePhotoAlbumTitleCommand request, CancellationToken cancellationToken)
    {
        var photoAlbum = await photoAlbumRepository.FindAsync(request.PhotoAlbumId, cancellationToken);

        if (photoAlbum is null)
        {
            // TODO: Implement Exception
            throw new ArgumentException(string.Empty);
        }

        photoAlbum.Title = request.Title;

        await photoAlbumRepository.UpdateAsync(photoAlbum, cancellationToken);

        return Unit.Value;
    }
}
