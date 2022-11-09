using PS.Shared.Application.CQRS.Commands;

namespace PS.Storage.Application.Commands.Delete;

public record DeleteFileCommand(string FileName) : ICommand<bool>;
