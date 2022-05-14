using Pic.Data.Entities;

namespace Pic.Core.Domain.PhotoAlbums.Commands;

public class DeletePhotoAlbumsCommandHandler : IRequestHandler<DeletePhotoAlbumsCommand>
{
    private readonly ILogger<DeletePhotoAlbumsCommandHandler> logger;
    private readonly IFileService fileService;
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public DeletePhotoAlbumsCommandHandler(ILogger<DeletePhotoAlbumsCommandHandler> logger, IFileService fileService, IPhotoAlbumRepository photoAlbumRepository)
    {
        this.logger = logger;
        this.fileService = fileService;
        this.photoAlbumRepository = photoAlbumRepository;
    }

    public async Task<Unit> Handle(DeletePhotoAlbumsCommand request, CancellationToken cancellationToken)
    {
        using var scope = logger.BeginScope(new Dictionary<string, object>
        {
            ["Action"] = nameof(DeletePhotoAlbumsCommand),
        });

        await foreach (var photoAlbum in photoAlbumRepository.FindAlbumsMarkedAsDeleted())
        {
            await TryDeletePhotoAlbum(photoAlbum, cancellationToken);
        }

        return Unit.Value;
    }

    private async Task TryDeletePhotoAlbum(PhotoAlbum photoAlbum, CancellationToken cancellationToken)
    {
        using var albumScope = logger.BeginScope(new Dictionary<string, object>
        {
            ["PhotoAlbumId"] = photoAlbum.Id,
            ["DirectoryName"] = photoAlbum.DirectoryName,
        });

        var isDeleted = fileService.SecureDeleteDirectory(photoAlbum.DirectoryName);

        if (isDeleted)
        {
            logger.LogInformation("Deleted directory.");

            logger.LogInformation("Deleting entity");

            photoAlbumRepository.Delete(photoAlbum);
            await photoAlbumRepository.SaveChanges(cancellationToken);

            logger.LogInformation("Deleted entity.");
        }
        else
        {
            logger.LogError("Failed to delete Photo Album.");
        }
    }
}
