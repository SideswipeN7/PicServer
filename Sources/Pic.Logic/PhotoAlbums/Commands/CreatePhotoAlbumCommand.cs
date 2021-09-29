namespace Pic.Logic.Photos.Commands;

public record CreatePhotoAlbumCommand(string Title) : IRequest<int>;
