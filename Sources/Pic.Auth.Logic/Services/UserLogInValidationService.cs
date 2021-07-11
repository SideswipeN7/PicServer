using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pic.Auth.Data.Entities;
using Pic.Auth.Data.Interfaces;
using Pic.Auth.Logic.Interfaces.Services;
using Pic.Auth.Logic.Models;
using Pic.Shared.Exceptions;

namespace Pic.Auth.Logic.Services
{
    public class UserLogInValidationService : IUserLogInValidationService
    {
        //TODO: Move to configuration
        private const int MaxInvalidRetries = 5;
        //TODO: Move to configuration
        private const int WaitTimeBeforeFailedLoginAttemptsCountCleredInSeconds = 5 * 60;

        private readonly ILogger<UserLogInValidationService> logger = default!;
        private readonly IPasswordService passwordService = default!;
        private readonly IIdentityUserRepository userRepository = default!;

        public UserLogInValidationService(
            ILogger<UserLogInValidationService> logger,
            IPasswordService passwordService,
            IIdentityUserRepository userRepository)
        {
            this.logger = logger;
            this.passwordService = passwordService;
            this.userRepository = userRepository;
        }

        public async Task ValidateLogInAttemptAndSetUserFlagsAsync(IdentityUser? user, LogInModel loginModel)
        {
            ValidateUserExists(user, loginModel);

            ValidateUserIsNotDeleted(user!, loginModel);

            ValidateUserIsActivated(user!, loginModel);

            await ValidateLockedLoginIsNotViolatedAsync(user!, loginModel);

            await ValidateIsCorrectPasswordAndLockLogInAttemptsIfNessaryAsync(user!, loginModel);
        }

        private void ValidateUserExists(IdentityUser? user, LogInModel loginModel)
        {
            if (user is null)
            {
                logger.LogError($"LogIn failed, no user found, UserName: '{loginModel.UserName}'.");

                throw new AppException("Failed login");
            }
        }

        private void ValidateUserIsNotDeleted(IdentityUser user, LogInModel loginModel)
        {
            if (user.IsDeleted)
            {
                logger.LogError($"LogIn failed, user UserName: '{loginModel.UserName}' is marked as deleted.");

                throw new AppException("Failed login");
            }
        }

        private void ValidateUserIsActivated(IdentityUser user, LogInModel loginModel)
        {
            if (!user.IsActivated)
            {
                logger.LogError($"LogIn failed, user UserName: '{loginModel.UserName}' is not activated.");

                throw new AppException("Failed login");
            }
        }

        private async Task ValidateLockedLoginIsNotViolatedAsync(IdentityUser user, LogInModel loginModel)
        {
            if (user.FailedLoginAttemptsCountExpiryDate.HasValue)
            {
                var isNotInTime = DateTime.UtcNow < user.FailedLoginAttemptsCountExpiryDate;
                if (isNotInTime)
                {
                    var failedLoginAttemptsCountExpiryDate = DateTime.UtcNow.AddSeconds(WaitTimeBeforeFailedLoginAttemptsCountCleredInSeconds);

                    logger.LogError($"LogIn failed, user UserName: '{loginModel.UserName}' wait time before log in violated. LogIn locked until {failedLoginAttemptsCountExpiryDate.ToLongDateString()}.");

                    user.FailedLoginAttemptsCountExpiryDate = failedLoginAttemptsCountExpiryDate;
                    await userRepository.SaveChangesAsync();
                }
            }
        }

        private async Task ValidateIsCorrectPasswordAndLockLogInAttemptsIfNessaryAsync(IdentityUser user, LogInModel loginModel)
        {
            if (passwordService.IsSamePassword(user.PasswordHash, loginModel.Password))
            {
                user.FailedLoginAttemptsCount++;
                logger.LogError($"LogIn failed, user UserName: '{loginModel.UserName}' wrong password.");

                if (user.FailedLoginAttemptsCount > MaxInvalidRetries)
                {
                    var failedLoginAttemptsCountExpiryDate = DateTime.UtcNow.AddSeconds(WaitTimeBeforeFailedLoginAttemptsCountCleredInSeconds);

                    logger.LogError($"LogIn failed, user UserName: '{loginModel.UserName}' log in locked until {failedLoginAttemptsCountExpiryDate.ToLongDateString()}.");

                    user.FailedLoginAttemptsCountExpiryDate = failedLoginAttemptsCountExpiryDate;
                    await userRepository.SaveChangesAsync();
                }

                throw new AppException("Failed login");
            }
        }
    }
}
