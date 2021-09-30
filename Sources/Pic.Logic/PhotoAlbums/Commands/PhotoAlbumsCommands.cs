namespace Pic.Logic.PhotoAlbums.Commands;

public record CreatePhotoAlbumCommand(string Title) : IRequest<int>;

public record DeletePhotoAlbumsCommand() : IRequest;

public record MarkPhotoAlbumsAsDeletedCommand(IEnumerable<int> PhotoAlbumIds) : IRequest;

public record RestorePhotoAlbumsCommand(IEnumerable<int> PhotoAlbumIds) : IRequest;

public record UpdatePhotoAlbumTitleCommand(int PhotoAlbumId, string Title) : IRequest;
