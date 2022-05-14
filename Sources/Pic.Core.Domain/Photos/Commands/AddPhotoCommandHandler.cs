namespace Pic.Core.Domain.Photos.Commands;

public class AddPhotoCommandHandler : IRequestHandler<AddPhotoCommand>
{
    private readonly ILogger<AddPhotoCommandHandler> logger;
    private readonly INameGenerationService nameGenerationService;
    private readonly IThumbnailGenerationService thumbnailGenerationService;
    private readonly IPathGenerationService pathGenerationService;
    private readonly IPhotoAlbumRepository photoAlbumRepository;
    private readonly IPhotoRepository photoRepository;

    public AddPhotoCommandHandler(
        ILogger<AddPhotoCommandHandler> logger,
        INameGenerationService nameGenerationService,
        IThumbnailGenerationService thumbnailGenerationService,
        IPathGenerationService pathGenerationService,
        IPhotoAlbumRepository photoAlbumRepository,
        IPhotoRepository photoRepository)
    {
        this.logger = logger;
        this.nameGenerationService = nameGenerationService;
        this.thumbnailGenerationService = thumbnailGenerationService;
        this.pathGenerationService = pathGenerationService;
        this.photoAlbumRepository = photoAlbumRepository;
        this.photoRepository = photoRepository;
    }

    public async Task<Unit> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
    {
        using var scope = logger.BeginScope(new Dictionary<string, object>
        {
            ["Action"] = nameof(AddPhotoCommand),
            ["PhotoAlbumId"] = request.PhotoAlbumId,
        });

        logger.LogInformation("Searching Photo Album with ID: {PhotoAlbumId}.", request.PhotoAlbumId);
        var photoAlbum = await photoAlbumRepository.FindAsync(request.PhotoAlbumId, cancellationToken);

        if (photoAlbum is null)
        {
            logger.LogError("Could not found Photo Album with ID: {PhotoAlbumId}.", request.PhotoAlbumId);
            throw new DomainException("Unable to add Photo");
        }

        var fileName = nameGenerationService.Generate();

        var path = pathGenerationService.GeneratePath(photoAlbum.DirectoryName, fileName);

        logger.LogInformation("Saving Photo in path: \"{PhotoPath}\".", path);
        await File.WriteAllBytesAsync(path, request.ImageBytes, cancellationToken);

        logger.LogInformation("Saving Photo in database");
        await photoRepository.Insert(
            new Photo
            {
                PhotoAlbumId = photoAlbum.Id,
                FileName = fileName,
                Name = request.Name,
                Thumbnail = thumbnailGenerationService.Generate(request.ImageBytes),
            },
            cancellationToken);
        await photoRepository.SaveChanges(cancellationToken);

        logger.LogInformation("Saved Photo.");

        return Unit.Value;
    }
}
