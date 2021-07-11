using System.Threading.Tasks;
using Pic.Auth.Data.Interfaces;
using Pic.Auth.Logic.Interfaces.Services;
using Pic.Auth.Logic.Models;
using Pic.Shared.Exceptions;

namespace Pic.Auth.Logic.Services
{
    public class UserRegistrationValidationService : IUserRegistrationValidationService
    {
        private readonly IIdentityUserRepository userRepository = default!;

        public UserRegistrationValidationService(IIdentityUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task ValidateRegistrationFormAsync(RegisterUserModel registerUserModel)
        {
            await ValidateUserNameNotTakenAsync(registerUserModel.UserName);
            ValidatePassordsMatch(registerUserModel);
        }

        private async Task ValidateUserNameNotTakenAsync(string userName)
        {
            var isUserInDb = await userRepository.CheckUserExistsAsync(userName);
            if (isUserInDb)
            {
                throw new AppException("UserName taken");
            }
        }

        private static void ValidatePassordsMatch(RegisterUserModel registerUserModel)
        {
            if (registerUserModel.Password != registerUserModel.RepeatedPassword)
            {
                throw new AppException("Password miss match");
            }
        }
    }
}