namespace Pic.Core.Domain.Photos.Commands;
public record AddPhotoCommand(int PhotoAlbumId, byte[] ImageBytes, string Name) : IRequest;
