using Pic.Data.Interfaces.Repositories;
using Pic.Logic.Interfaces;
using Pic.Logic.Photos.Commands;

namespace Pic.Logic.PhotoAlbums.Commands;

public class UpdatePhotoAlbumTitleCommandHandler : IRequestHandler<UpdatePhotoAlbumTitleCommand>
{
    private readonly INameGenerationService nameGenerationService;
    private readonly IPhotoAlbumRepository photoAlbumRepository;
    private readonly IFileService fileService;

    public UpdatePhotoAlbumTitleCommandHandler(INameGenerationService nameGenerationService, IPhotoAlbumRepository photoAlbumRepository, IFileService fileService)
    {
        this.nameGenerationService = nameGenerationService;
        this.photoAlbumRepository = photoAlbumRepository;
        this.fileService = fileService;
    }

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
