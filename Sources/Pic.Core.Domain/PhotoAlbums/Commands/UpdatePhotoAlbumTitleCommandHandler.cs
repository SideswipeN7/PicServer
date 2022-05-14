namespace Pic.Core.Domain.PhotoAlbums.Commands;

public class UpdatePhotoAlbumTitleCommandHandler : IRequestHandler<UpdatePhotoAlbumTitleCommand>
{
    private readonly ILogger<RestorePhotoAlbumsCommandHandler> logger;
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public UpdatePhotoAlbumTitleCommandHandler(ILogger<RestorePhotoAlbumsCommandHandler> logger, IPhotoAlbumRepository photoAlbumRepository)
    {
        this.logger = logger;
        this.photoAlbumRepository = photoAlbumRepository;
    }

    public async Task<Unit> Handle(UpdatePhotoAlbumTitleCommand request, CancellationToken cancellationToken)
    {
        using var scope = logger.BeginScope(new Dictionary<string, object>
        {
            ["Action"] = nameof(UpdatePhotoAlbumTitleCommand),
            ["PhotoAlbumId"] = request.PhotoAlbumId,
        });

        logger.LogInformation("Find Photo Album with ID {PhotoAlbumId}.", request.PhotoAlbumId);
        var photoAlbum = await photoAlbumRepository.FindAsync(request.PhotoAlbumId, cancellationToken);

        if (photoAlbum is null)
        {
            logger.LogError("Could not find Photo Album with ID {PhotoAlbumId}.", request.PhotoAlbumId);
            throw new DomainException("Photo Album does not exists.");
        }

        logger.LogInformation("Updating title from: \"{PhotoAlbumName}\" to: \"{NewPhotoAlbumName}\".", photoAlbum.Title, request.Title);
        photoAlbum.Title = request.Title;

        photoAlbumRepository.Update(photoAlbum);
        await photoAlbumRepository.SaveChanges(cancellationToken);
        logger.LogInformation("Photo Album title updated.");

        return Unit.Value;
    }
}
