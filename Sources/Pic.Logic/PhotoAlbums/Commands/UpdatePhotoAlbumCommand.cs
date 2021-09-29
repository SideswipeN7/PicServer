namespace Pic.Logic.Photos.Commands;

public record UpdatePhotoAlbumCommand(int PhotoAlbumId, string Title) : IRequest;
