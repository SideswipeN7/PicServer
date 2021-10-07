namespace Pic.Logic.PhotoAlbums.Queries;

internal class GetPhotoAlbumsInfoQueryHandler : IRequestHandler<GetPhotoAlbumsInfoQuery, IEnumerable<AlbumInfo>>
{
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public GetPhotoAlbumsInfoQueryHandler(IPhotoAlbumRepository photoAlbumRepository)
    {
        this.photoAlbumRepository = photoAlbumRepository;
    }

    public async Task<IEnumerable<AlbumInfo>> Handle(GetPhotoAlbumsInfoQuery request, CancellationToken cancellationToken)
    {
        return await photoAlbumRepository.GetPhotoAlbumsInfosAsync().ToListAsync(cancellationToken);
    }
}
