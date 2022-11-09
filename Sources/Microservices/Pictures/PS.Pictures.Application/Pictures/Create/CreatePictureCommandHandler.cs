using MediatR;
using PS.Pictures.Application.Exceptions.Extensions;
using PS.Pictures.Application.Extensions;
using PS.Pictures.Domain.Pictures;
using PS.Shared.Application.CQRS.Commands;

namespace PS.Pictures.Application.Pictures.Create;

internal class CreatePictureCommandHandler : ICommandHandler<CreatePictureCommand>
{
    private readonly IPictureRepository repository;

    public CreatePictureCommandHandler(IPictureRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);

        this.repository = repository;
    }

    public async Task<Unit> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
    {
        await Validate(request, cancellationToken);
        var entity = Picture.Create(request.Uid, request.Owner, request.AsState());

        await repository.Add(entity, cancellationToken);

        return Unit.Value;
    }

    private async Task Validate(CreatePictureCommand request, CancellationToken cancellationToken)
    {
        var isUnique = await repository.IsFileNameUniqueForOwner(request.Owner, request.FileName, cancellationToken);

        request.FileName.ThrowIfFilenameNotUnique(isUnique);
    }
}
