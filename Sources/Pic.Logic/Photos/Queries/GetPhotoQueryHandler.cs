namespace Pic.Logic.Photos.Queries;

public class GetPhotoQueryHandler : IRequestHandler<GetPhotoQuery, byte[]?>
{
    public Task<byte[]?> Handle(GetPhotoQuery request, CancellationToken cancellationToken)
    {
        var folder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
        var path = Path.Combine(folder, "..", "..", request.PhotoName);

        if (!File.Exists(path))
        {
            return Task.FromResult<byte[]?>(null);
        }

        return File.ReadAllBytesAsync(path, cancellationToken);
    }
}
