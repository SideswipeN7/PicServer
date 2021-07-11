using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pic.Auth.Data.Entities;
using Pic.Auth.Data.Interfaces;
using Pic.Shared.Data.Repositories;

namespace Pic.Auth.Data.Repositories
{
    public class IdentityUserRepository : GenericRepository<IdentityUser>, IIdentityUserRepository
    {
        public IdentityUserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> CheckUserExistsAsync(string userName)
        {
            return context.AnyAsync(u => u.UserName == userName);
        }

        public Task<IdentityUser?> FindUserAsycAsync(string userName)
        {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return context.FirstOrDefaultAsync(u => u.UserName == userName);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }
    }
}