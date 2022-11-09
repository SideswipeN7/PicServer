using PS.Shared.Application.CQRS.Queries;
using PS.Shared.Application.Exceptions.Extensions;
using PS.Storage.Application.Exceptions.Extensions;
using PS.Storage.Application.Interfaces;

namespace PS.Storage.Application.Queries;

internal class ReadFileQueryHandler : IQueryHandler<ReadFileQuery, byte[]>
{
    private readonly IFileService service;

    public ReadFileQueryHandler(IFileService service) => this.service = service;

    public async Task<byte[]> Handle(ReadFileQuery request, CancellationToken cancellationToken)
    {
        var bytes = await service.TryReadFile(request.FileName, cancellationToken);

        bytes.ThrowIfNotFound(request.FileName);

        return bytes!;
    }
}
