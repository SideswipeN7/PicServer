using System.Threading.Tasks;
using Pic.Auth.Data.Interfaces;
using Pic.Auth.Logic.Interfaces.Services;
using Pic.Auth.Logic.Models;
using Pic.Shared.Exceptions;

namespace Pic.Auth.Logic.UseCases
{
    public class UserLogsInUsingClientIdUseCase
    {
        private readonly IIdentityUserRepository userRepository = default!;
        private readonly IUserLogInValidationService userLogInValidationService = default!;
        private readonly IJWTGenerationService jwtGenerationService = default!;
        private readonly IClientConfigurationRepository clientConfigurationRepository = default!;

        public UserLogsInUsingClientIdUseCase(
            IIdentityUserRepository userRepository,
            IUserLogInValidationService userLogInValidationService,
            IJWTGenerationService jwtGenerationService,
            IClientConfigurationRepository clientConfigurationRepository)
        {
            this.userRepository = userRepository;
            this.userLogInValidationService = userLogInValidationService;
            this.jwtGenerationService = jwtGenerationService;
            this.clientConfigurationRepository = clientConfigurationRepository;
        }

        public async Task<string> LogInAsync(LogInModel loginModel)
        {
            var clientConfiguration = await clientConfigurationRepository.FindByClientIdAsync(loginModel.ClientId);

            if (clientConfiguration is null)
            {
                throw new AppException("Client not found");
            }

            var user = await userRepository.FindUserAsycAsync(loginModel.UserName);

            await userLogInValidationService.ValidateLogInAttemptAndSetUserFlagsAsync(user, loginModel);

            user!.FailedLoginAttemptsCountExpiryDate = null;
            user!.FailedLoginAttemptsCount = 0;

            return jwtGenerationService.GenerateToken(clientConfiguration, user);
        }
    }
}