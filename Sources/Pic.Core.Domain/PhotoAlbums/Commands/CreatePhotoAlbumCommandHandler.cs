namespace Pic.Core.Domain.PhotoAlbums.Commands;

public class CreatePhotoAlbumCommandHandler : IRequestHandler<CreatePhotoAlbumCommand, int>
{
    private readonly ILogger<CreatePhotoAlbumCommandHandler> logger;
    private readonly INameGenerationService nameGenerationService;
    private readonly IFileService fileService;
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public CreatePhotoAlbumCommandHandler(ILogger<CreatePhotoAlbumCommandHandler> logger, INameGenerationService nameGenerationService, IFileService fileService, IPhotoAlbumRepository photoAlbumRepository)
    {
        this.logger = logger;
        this.nameGenerationService = nameGenerationService;
        this.fileService = fileService;
        this.photoAlbumRepository = photoAlbumRepository;
    }

    public async Task<int> Handle(CreatePhotoAlbumCommand request, CancellationToken cancellationToken)
    {
        using var scope = logger.BeginScope(new Dictionary<string, object>
        {
            ["Action"] = nameof(CreatePhotoAlbumCommand),
        });

        var photoAlbum = CreatePhotoAlbum(request);

        var isCreated = CreateDirectory(photoAlbum.DirectoryName);

        if (!isCreated)
        {
            throw new DomainException("Could not create Photo Album. Please Try Later.");
        }

        await SavePhotoAlbum(photoAlbum, cancellationToken);

        return photoAlbum.Id;
    }

    private PhotoAlbum CreatePhotoAlbum(CreatePhotoAlbumCommand request)
    {
        logger.LogInformation("Creating Photo Album with title {AlbumTitle}", request.Title);

        return new PhotoAlbum
        {
            DirectoryName = nameGenerationService.Generate(),
            Title = request.Title,
            Synopsis = request.Synopsis,
        };
    }

    private bool CreateDirectory(string directoryName)
    {
        try
        {
            logger.LogInformation("Creating folder {DirectoryName}", directoryName);

            return fileService.CreateDirectory(directoryName);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to create directory with name {DirectoryName}", directoryName);

            return false;
        }
    }

    private async Task SavePhotoAlbum(PhotoAlbum photoAlbum, CancellationToken cancellationToken)
    {
        logger.LogInformation("Saving photo album.");

        await photoAlbumRepository.Insert(photoAlbum);
        await photoAlbumRepository.SaveChanges(cancellationToken);

        logger.LogInformation("Saved photo album.");
    }
}
