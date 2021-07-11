using System.Threading.Tasks;
using Pic.Auth.Data.Entities;
using Pic.Auth.Data.Interfaces;
using Pic.Auth.Logic.Interfaces.Services;
using Pic.Auth.Logic.Models;

namespace Pic.Auth.Logic.UseCases
{
    public class UserRegisterNewUserUseCase
    {
        private readonly IIdentityUserRepository userRepository = default!;
        private readonly IPasswordService passwordService = default!;
        private readonly IUserRegistrationValidationService userRegistrationValidationService = default!;

        public UserRegisterNewUserUseCase(
            IIdentityUserRepository userRepository,
            IPasswordService passwordService,
            IUserRegistrationValidationService userRegistrationValidationService)
        {
            this.userRepository = userRepository;
            this.passwordService = passwordService;
            this.userRegistrationValidationService = userRegistrationValidationService;
        }

        public async Task RegisterNewUserAsync(RegisterUserModel registerUserModel)
        {
            await userRegistrationValidationService.ValidateRegistrationFormAsync(registerUserModel);
            await RegisterUserAsync(registerUserModel.UserName, registerUserModel.Password);
        }

        private async Task RegisterUserAsync(string userName, string password)
        {
            var user = new IdentityUser
            {
                UserName = userName,
                PasswordHash = passwordService.CreatePasswordHash(password),
            };

            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
        }
    }
}