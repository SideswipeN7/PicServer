using PS.Shared.Application.CQRS.Commands;
using PS.Storage.Application.Exceptions.Extensions;
using PS.Storage.Application.Interfaces;

namespace PS.Storage.Application.Commands.Upload;

internal class UploadFileCommandHandler : ICommandHandler<UploadFileCommand, Guid>
{
    private readonly IFileService _service;

    public UploadFileCommandHandler(IFileService service) => _service = service;

    public async Task<Guid> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var newFileName = Guid.NewGuid();

        var isSaved = await _service.TrySaveFile(request.FileBytes, newFileName.ToString(), cancellationToken);

        isSaved.ThrowIfNotSaved(request.OriginalFileName);

        return newFileName;
    }
}
