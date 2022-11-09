using PS.Shared.Application.CQRS.Commands;
using PS.Storage.Application.Commands.Upload;
using PS.Storage.Application.Interfaces;

namespace PS.Storage.Application.Commands.Delete;

internal class DeleteFileCommandHandler : ICommandHandler<DeleteFileCommand, bool>
{
    private readonly IFileService _service;

    public DeleteFileCommandHandler(IFileService service) => _service = service;

    public Task<bool> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        var isDeleted = _service.DeleteFile(request.FileName, cancellationToken);

        return Task.FromResult(isDeleted);
    }
}
