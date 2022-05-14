namespace Pic.Core.Domain.PhotoAlbums.Commands;

public class RestorePhotoAlbumsCommandHandler : IRequestHandler<RestorePhotoAlbumsCommand>
{
    private readonly ILogger<RestorePhotoAlbumsCommandHandler> logger;
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public RestorePhotoAlbumsCommandHandler(ILogger<RestorePhotoAlbumsCommandHandler> logger, IPhotoAlbumRepository photoAlbumRepository)
    {
        this.logger = logger;
        this.photoAlbumRepository = photoAlbumRepository;
    }

    public async Task<Unit> Handle(RestorePhotoAlbumsCommand request, CancellationToken cancellationToken)
    {
        using var scope = logger.BeginScope(new Dictionary<string, object>
        {
            ["Action"] = nameof(RestorePhotoAlbumsCommand),
            ["PhotoAlbumsIds"] = request.PhotoAlbumIds,
        });

        logger.LogInformation("Marking Photo Album with IDs: {PhotoAlbumsIds} as not Deleted.", string.Join(", ", request.PhotoAlbumIds));

        var photoAlbums = photoAlbumRepository.FindAlbumsMarkedAsDeleted(request.PhotoAlbumIds);

        await photoAlbums.ForEachAsync(pa => pa.IsDeleted = true, cancellationToken);

        await photoAlbumRepository.SaveChanges(cancellationToken);
        logger.LogInformation("All selected Photo Albums marked as Deleted.");

        return Unit.Value;
    }
}
