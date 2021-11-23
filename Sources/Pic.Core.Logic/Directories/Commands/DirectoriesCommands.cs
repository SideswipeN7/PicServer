namespace Pic.Core.Logic.Directories.Commands;

public record CreateDirectoryCommand(string DirectoryName) : IRequest<bool>;

public record DeleteDirectoryCommand(string DirectoryName) : IRequest<bool>;
