using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pic.Auth.Data.Entities;
using Pic.Auth.Data.Interfaces;
using Pic.Shared.Data.Repositories;

namespace Pic.Auth.Data.Repositories
{
    public class ClientConfigurationRepository : GenericRepository<ClientConfiguration>, IClientConfigurationRepository
    {
        public ClientConfigurationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<ClientConfiguration?> FindByClientIdAsync(string clientId)
        {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return context.Where(c => c.ClientId == clientId)
                .Include(c => c.Claims)
                .FirstOrDefaultAsync();
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }
    }
}
