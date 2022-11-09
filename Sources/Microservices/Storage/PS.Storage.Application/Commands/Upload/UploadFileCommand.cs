using PS.Shared.Application.CQRS.Commands;

namespace PS.Storage.Application.Commands.Upload;

public record UploadFileCommand(string OriginalFileName, byte[] FileBytes) : ICommand<Guid>;
