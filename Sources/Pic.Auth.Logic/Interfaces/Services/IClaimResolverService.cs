using System.Security.Claims;
using Pic.Auth.Data.Entities;

namespace Pic.Auth.Logic.Interfaces.Services
{
    public interface IClaimResolverService
    {
        Claim ResolveClaim(ClientClaim c, IdentityUser user);
    }
}