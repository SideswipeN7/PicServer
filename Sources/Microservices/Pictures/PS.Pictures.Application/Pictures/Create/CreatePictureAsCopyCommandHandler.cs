using MediatR;
using PS.Pictures.Application.Extensions;
using PS.Pictures.Domain.Pictures;
using PS.Shared.Application.CQRS.Commands;

namespace PS.Pictures.Application.Pictures.Create;

internal class CreatePictureAsCopyCommandHandler : ICommandHandler<CreatePictureAsCopyCommand>
{
    private readonly IPictureRepository repository;

    public CreatePictureAsCopyCommandHandler(IPictureRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);

        this.repository = repository;
    }

    public async Task<Unit> Handle(CreatePictureAsCopyCommand request, CancellationToken cancellationToken)
    {
        var newFilename = await ProcessFileName(request, cancellationToken);

        var entity = Picture.Create(request.Uid, request.Owner, request.AsState() with { FileName = newFilename });

        await repository.Add(entity, cancellationToken);

        return Unit.Value;
    }

    private async Task<string> ProcessFileName(CreatePictureAsCopyCommand request, CancellationToken cancellationToken)
    {
        var (pureFileName, extension) = request.FileName.GetFileNameWithExtension();

        var count = await repository.GetSimilarNameCount(request.Owner, pureFileName, cancellationToken);

        return $"{pureFileName.Trim()} ({count}).{extension}";
    }
}
