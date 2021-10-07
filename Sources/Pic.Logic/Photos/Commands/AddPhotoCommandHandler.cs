namespace Pic.Logic.Photos.Commands;

public class AddPhotoCommandHandler : IRequestHandler<AddPhotoCommand>
{
    public async Task<Unit> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
    {
        var folder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
        var path = Path.Combine(folder, "..", "..", request.Name);

        await File.WriteAllBytesAsync(path, request.ImageBytes, cancellationToken);

        return Unit.Value;
    }
}
