namespace Pic.Core.Logic.Photos.Queries;

public record GetPhotoByIdQuery(int PhotoId) : IRequest<byte[]>;
