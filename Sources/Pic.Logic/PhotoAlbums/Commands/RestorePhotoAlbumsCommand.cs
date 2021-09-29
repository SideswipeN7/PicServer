namespace Pic.Logic.Photos.Commands;

public record RestorePhotoAlbumsCommand(IEnumerable<int> PhotoAlbumIds) : IRequest;
