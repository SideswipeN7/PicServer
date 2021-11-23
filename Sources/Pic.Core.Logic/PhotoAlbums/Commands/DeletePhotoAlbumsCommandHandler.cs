using Pic.Core.Logic.Directories.Commands;

namespace Pic.Core.Logic.PhotoAlbums.Commands;

public class DeletePhotoAlbumsCommandHandler : IRequestHandler<DeletePhotoAlbumsCommand>
{
    private readonly IPhotoAlbumRepository photoAlbumRepository;
    private readonly IMediator mediator;

    public DeletePhotoAlbumsCommandHandler(IPhotoAlbumRepository photoAlbumRepository, IMediator mediator)
    {
        this.photoAlbumRepository = photoAlbumRepository;
        this.mediator = mediator;
    }

    public async Task<Unit> Handle(DeletePhotoAlbumsCommand request, CancellationToken cancellationToken)
    {
        var photoAlbums = photoAlbumRepository.FindAlbumsMarkedAsDeleted();
        var photoAlbumsToDelete = new List<PhotoAlbum>();

        await foreach (var photoAlbum in photoAlbums)
        {
            var isDeleted = await mediator.Send(new DeleteDirectoryCommand(photoAlbum.FolderName));

            if (isDeleted)
            {
                photoAlbumsToDelete.Add(photoAlbum);
            }
        }

        await photoAlbumRepository.DeleteRangeAsync(photoAlbumsToDelete, cancellationToken);

        return Unit.Value;
    }
}
