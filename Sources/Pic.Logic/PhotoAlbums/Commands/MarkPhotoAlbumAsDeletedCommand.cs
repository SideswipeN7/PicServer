namespace Pic.Logic.Photos.Commands;

public record MarkPhotoAlbumAsDeletedCommand(int PhotoAlbumId) : IRequest;
