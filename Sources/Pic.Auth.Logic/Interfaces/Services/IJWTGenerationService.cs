using Pic.Auth.Data.Entities;

namespace Pic.Auth.Logic.Interfaces.Services
{
    public interface IJWTGenerationService
    {
        string GenerateToken(ClientConfiguration clientConfiguration, IdentityUser user);
    }
}