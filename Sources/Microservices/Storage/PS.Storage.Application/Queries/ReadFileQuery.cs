using PS.Shared.Application.CQRS.Queries;

namespace PS.Storage.Application.Queries;

public record ReadFileQuery(string FileName) : IQuery<byte[]>;
