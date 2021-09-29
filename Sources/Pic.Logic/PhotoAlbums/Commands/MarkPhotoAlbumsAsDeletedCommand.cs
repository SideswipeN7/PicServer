namespace Pic.Logic.Photos.Commands;

public record MarkPhotoAlbumsAsDeletedCommand(IEnumerable<int> PhotoAlbumIds) : IRequest;
