namespace Pic.Core.Domain.PhotoAlbums.Commands;

public class MarkPhotoAlbumsAsDeletedCommandHandler : IRequestHandler<MarkPhotoAlbumsAsDeletedCommand>
{
    private readonly ILogger<MarkPhotoAlbumsAsDeletedCommand> logger;
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public MarkPhotoAlbumsAsDeletedCommandHandler(ILogger<MarkPhotoAlbumsAsDeletedCommand> logger, IPhotoAlbumRepository photoAlbumRepository)
    {
        this.logger = logger;
        this.photoAlbumRepository = photoAlbumRepository;
    }

    public async Task<Unit> Handle(MarkPhotoAlbumsAsDeletedCommand request, CancellationToken cancellationToken)
    {
        using var scope = logger.BeginScope(new Dictionary<string, object>
        {
            ["Action"] = nameof(MarkPhotoAlbumsAsDeletedCommand),
        });

        logger.LogInformation("Marking Photo Albums with IDs: {PhotoAlbumsIds} as Deleted.", string.Join(", ", request.PhotoAlbumIds));

        var photoAlbums = photoAlbumRepository.FindAlbums(request.PhotoAlbumIds);

        await photoAlbums.ForEachAsync(pa => pa.IsDeleted = true, cancellationToken);

        await photoAlbumRepository.SaveChanges(cancellationToken);
        logger.LogInformation("All selected Photo Albums marked as Deleted.");

        return Unit.Value;
    }
}
