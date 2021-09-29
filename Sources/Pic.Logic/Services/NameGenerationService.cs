using Pic.Logic.Interfaces;

namespace Pic.Logic.Services;

public class NameGenerationService : INameGenerationService
{
    public string Generate() => $"{DateTimeOffset.UtcNow}_{Guid.NewGuid()}";
}
