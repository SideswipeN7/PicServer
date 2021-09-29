using Pic.Data.Interfaces.Repositories;
using Pic.Data.Models;
using Pic.Logic.Interfaces;
using Pic.Logic.Photos.Commands;

namespace Pic.Logic.PhotoAlbums.Commands;

public class DeletePhotoAlbumsCommandHandler : IRequestHandler<DeletePhotoAlbumsCommand>
{
    private readonly IPhotoAlbumRepository photoAlbumRepository;
    private readonly IFileService fileService;

    public DeletePhotoAlbumsCommandHandler(IPhotoAlbumRepository photoAlbumRepository, IFileService fileService)
    {
        this.photoAlbumRepository = photoAlbumRepository;
        this.fileService = fileService;
    }

    public async Task<Unit> Handle(DeletePhotoAlbumsCommand request, CancellationToken cancellationToken)
    {
        var photoAlbums = photoAlbumRepository.FindAlbumsMarkedAsDeleted();
        var photoAlbumsToDelete = new List<PhotoAlbum>();


        await foreach (var photoAlbum in photoAlbums)
        {
            var isDeleted = fileService.RemoveFolder(photoAlbum.FolderName);

            if (isDeleted)
            {
                photoAlbumsToDelete.Add(photoAlbum);
            }
        }

        await photoAlbumRepository.DeleteRangeAsync(photoAlbumsToDelete, cancellationToken);

        return Unit.Value;
    }
}
