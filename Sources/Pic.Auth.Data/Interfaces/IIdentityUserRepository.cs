using System.Threading.Tasks;
using Pic.Auth.Data.Entities;
using Pic.Shared.Data.Interfaces;

namespace Pic.Auth.Data.Interfaces
{
    public interface IIdentityUserRepository : IRepository<IdentityUser>
    {
        Task<bool> CheckUserExistsAsync(string userName);

        Task<IdentityUser?> FindUserAsycAsync(string userName);
    }
}