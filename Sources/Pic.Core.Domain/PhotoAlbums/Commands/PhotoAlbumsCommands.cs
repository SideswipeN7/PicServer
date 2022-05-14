namespace Pic.Core.Domain.PhotoAlbums.Commands;

public record CreatePhotoAlbumCommand(string Title, string? Synopsis) : IRequest<int>;

public record DeletePhotoAlbumsCommand() : IRequest;

public record MarkPhotoAlbumsAsDeletedCommand(IEnumerable<int> PhotoAlbumIds) : IRequest;

public record RestorePhotoAlbumsCommand(IEnumerable<int> PhotoAlbumIds) : IRequest;

public record UpdatePhotoAlbumTitleCommand(int PhotoAlbumId, string Title, string? Synopsis, byte[]? Thumbnail, int? PhotoIdForThumbnail) : IRequest;
