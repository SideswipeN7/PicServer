using MediatR;
using PS.Pictures.Domain.Pictures;
using PS.Shared.Application.CQRS.Commands;
using PS.Shared.Application.Exceptions.Extensions;

namespace PS.Pictures.Application.Pictures.Modify;

internal class EditPictureCommandHandler : ICommandHandler<EditPictureCommand>
{
    private readonly IPictureRepository repository;

    public EditPictureCommandHandler(IPictureRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);

        this.repository = repository;
    }

    public async Task<Unit> Handle(EditPictureCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByUidAndOwner(request.Uid, request.Owner, cancellationToken);

        entity.ThrowIfNotFound(request.Uid);

        entity!.Edit(request.AsState());

        await repository.Update(entity, cancellationToken);

        return Unit.Value;
    }
}
