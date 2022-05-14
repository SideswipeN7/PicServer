namespace Pic.Core.Logic.Services;

internal class PathGenerationService : IPathGenerationService
{
    private readonly ISettingsService settingsService;

    public PathGenerationService(ISettingsService settingsService)
    {
        this.settingsService = settingsService;
    }

    public string GeneratePath(string photoAlbumDirectory, string photoFileName)
    {
        return Path.Combine(settingsService.GetFilesPath(), photoAlbumDirectory, photoFileName);
    }
}
