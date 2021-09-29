namespace Pic.Logic.Photos.Commands;

public record UpdatePhotoAlbumTitleCommand(int PhotoAlbumId, string Title) : IRequest;
