namespace Pic.Core.Logic.Services;

internal class NameGenerationService : INameGenerationService
{
    public string Generate() => $"{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}_{Guid.NewGuid()}";
}
