namespace Pic.Logic.Photos.Queries
{
    public record GetPhotoQuery(string PhotoName) : IRequest<byte[]?>;
}
