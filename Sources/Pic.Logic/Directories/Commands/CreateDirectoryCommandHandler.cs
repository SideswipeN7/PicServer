namespace Pic.Logic.Directories.Commands;

public class CreateDirectoryCommandHandler : IRequestHandler<CreateDirectoryCommand, bool>
{
    private readonly IFileService fileService;
    private readonly ISettingsRepository settingsRepository;

    public CreateDirectoryCommandHandler(IFileService fileService, ISettingsRepository settingsRepository)
    {
        this.fileService = fileService;
        this.settingsRepository = settingsRepository;
    }

    public async Task<bool> Handle(CreateDirectoryCommand request, CancellationToken cancellationToken)
    {
        var path = await settingsRepository.FindSettingAsync(SettingsConstants.SaveFileLocation, cancellationToken);
        var fullPath = Path.Combine(path, request.DirectoryName);

        return fileService.CreateDirectory(fullPath);
    }
}
