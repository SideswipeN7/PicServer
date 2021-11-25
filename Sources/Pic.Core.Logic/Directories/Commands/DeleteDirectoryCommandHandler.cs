﻿using Pic.Core.Shared.Constants;

namespace Pic.Core.Logic.Directories.Commands;

public class DeleteDirectoryCommandHandler : IRequestHandler<DeleteDirectoryCommand, bool>
{
    private readonly IFileService fileService;
    private readonly ISettingsRepository settingsRepository;

    public DeleteDirectoryCommandHandler(IFileService fileService, ISettingsRepository settingsRepository)
    {
        this.fileService = fileService;
        this.settingsRepository = settingsRepository;
    }

    public async Task<bool> Handle(DeleteDirectoryCommand request, CancellationToken cancellationToken)
    {
        var path = await settingsRepository.FindSettingAsync(SettingsConstants.SaveFileLocation, cancellationToken) ?? string.Empty;
        var fullPath = Path.Combine(path, request.DirectoryName);

        return fileService.SecureDeleteDirectory(fullPath);
    }
}