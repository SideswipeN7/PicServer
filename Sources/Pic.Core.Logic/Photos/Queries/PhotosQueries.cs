namespace Pic.Core.Logic.Photos.Queries;

public record GetPhotoQuery(string PhotoName) : IRequest<byte[]>;
