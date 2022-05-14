namespace Pic.Core.Infrastructure.Interfaces.Services;

public interface IPathGenerationService
{
    string GeneratePath(string photoAlbumDirectory, string photoFileName);
}
