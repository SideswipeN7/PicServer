using Pic.Settings.Server.Configuration;
using Pic.Settings.Shared.Dto;
using System.Threading.Tasks;

namespace Pic.Settings.Server.Services
{
    public class AuthorizationService
    {
        private readonly Pic.Shared.ApiClient.Client apiClient;
        public AuthorizationService(ServiceConfiguration serviceConfiguration) => apiClient = new Pic.Shared.ApiClient.Client(serviceConfiguration.Address);

        public async Task<LogInResultDto> LogIn(CredentialsDto credentials) => await apiClient.Put<LogInResultDto>("/api/Authorization/Authorize", credentials);

        public async Task<bool> Register(CredentialsDto credentials) => await apiClient.Post<bool>("Register", credentials);
    }
}