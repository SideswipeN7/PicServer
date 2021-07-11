using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Pic.Auth.Data.Entities;
using Pic.Auth.Logic.Interfaces.Services;

namespace Pic.Auth.Logic.Services
{
    public class ClaimResolverService : IClaimResolverService
    {
        public Claim ResolveClaim(ClientClaim clientClaim, IdentityUser user) => new(clientClaim.Name, ResolveUserValue(clientClaim.Name, user) ?? string.Empty);

        private static string? ResolveUserValue(string claim, IdentityUser user) => claim switch
        {
            JwtClaimTypes.Subject => user.Id.ToString(),
            JwtClaimTypes.NickName => user.UserName,
            JwtClaimTypes.Email => user.EmailAddress,
            JwtClaimTypes.Role => user.Roles.Select(r => r.Name).ToString(),
            JwtClaimTypes.Picture => user.ProfilePicture,
            JwtClaimTypes.Confirmation => user.IsActivated.ToString(),
            _ => null,
        };
    }
}