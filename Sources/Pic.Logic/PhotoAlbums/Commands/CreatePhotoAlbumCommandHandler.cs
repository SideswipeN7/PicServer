using Pic.Data.Interfaces.Repositories;
using Pic.Data.Models;
using Pic.Logic.Interfaces;
using Pic.Logic.Photos.Commands;

namespace Pic.Logic.PhotoAlbums.Commands;

public class CreatePhotoAlbumCommandHandler : IRequestHandler<CreatePhotoAlbumCommand, int>
{
    private readonly INameGenerationService nameGenerationService;
    private readonly IPhotoAlbumRepository photoAlbumRepository;
    private readonly IFileService fileService;

    public CreatePhotoAlbumCommandHandler(INameGenerationService nameGenerationService, IPhotoAlbumRepository photoAlbumRepository, IFileService fileService)
    {
        this.nameGenerationService = nameGenerationService;
        this.photoAlbumRepository = photoAlbumRepository;
        this.fileService = fileService;
    }

    public async Task<int> Handle(CreatePhotoAlbumCommand request, CancellationToken cancellationToken)
    {
        var photoAlbum = new PhotoAlbum
        {
            FolderName = nameGenerationService.Generate(),
            Title = request.Title,
        };

        await photoAlbumRepository.InsertAsync(photoAlbum, cancellationToken);

        fileService.CreateDirectory(photoAlbum.FolderName);

        return photoAlbum.Id;
    }
}
