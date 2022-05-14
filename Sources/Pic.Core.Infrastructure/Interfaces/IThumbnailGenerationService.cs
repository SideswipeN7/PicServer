namespace Pic.Core.Infrastructure.Interfaces.Services;

public interface IThumbnailGenerationService
{
    byte[] Generate(byte[] image);
}
