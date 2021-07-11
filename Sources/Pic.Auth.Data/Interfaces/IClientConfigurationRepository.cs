using System.Threading.Tasks;
using Pic.Auth.Data.Entities;

namespace Pic.Auth.Data.Interfaces
{
    public interface IClientConfigurationRepository
    {
        public Task<ClientConfiguration?> FindByClientIdAsync(string clientId);
    }
}