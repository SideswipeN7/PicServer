namespace Pic.Core.Logic.PhotoAlbums.Queries;

internal class GetSinglePhotoAlbumInfoQueryHandler : IRequestHandler<GetSinglePhotoAlbumInfoQuery, AlbumInfo?>
{
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public GetSinglePhotoAlbumInfoQueryHandler(IPhotoAlbumRepository photoAlbumRepository)
    {
        this.photoAlbumRepository = photoAlbumRepository;
    }

    public async Task<AlbumInfo?> Handle(GetSinglePhotoAlbumInfoQuery request, CancellationToken cancellationToken)
    {
        return await photoAlbumRepository.GetSinglePhotoAlbumsInfo(request.Id, cancellationToken);
    }
}
