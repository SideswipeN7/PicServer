namespace Pic.Logic.Photos.Commands
{
    public record AddPhotoCommand(byte[] ImageBytes, string Name) : IRequest;
}
