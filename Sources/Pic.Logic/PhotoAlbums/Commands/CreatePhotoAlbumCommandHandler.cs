using Pic.Logic.Directories.Commands;

namespace Pic.Logic.PhotoAlbums.Commands;

public class CreatePhotoAlbumCommandHandler : IRequestHandler<CreatePhotoAlbumCommand, int>
{
    private readonly INameGenerationService nameGenerationService;
    private readonly IPhotoAlbumRepository photoAlbumRepository;
    private readonly IMediator mediator;

    public CreatePhotoAlbumCommandHandler(INameGenerationService nameGenerationService, IPhotoAlbumRepository photoAlbumRepository, IMediator mediator)
    {
        this.nameGenerationService = nameGenerationService;
        this.photoAlbumRepository = photoAlbumRepository;
        this.mediator = mediator;
    }

    public async Task<int> Handle(CreatePhotoAlbumCommand request, CancellationToken cancellationToken)
    {
        var photoAlbum = new PhotoAlbum
        {
            FolderName = nameGenerationService.Generate(),
            Title = request.Title,
        };

        await photoAlbumRepository.InsertAsync(photoAlbum, cancellationToken);

        var isCreated = await mediator.Send(new CreateDirectoryCommand(photoAlbum.FolderName));

        if (!isCreated)
        {
            await photoAlbumRepository.DeleteRangeAsync(new[] { photoAlbum }, cancellationToken);

            // TODO: Throw correct exception
            throw new Exception();
        }

        return photoAlbum.Id;
    }
}
