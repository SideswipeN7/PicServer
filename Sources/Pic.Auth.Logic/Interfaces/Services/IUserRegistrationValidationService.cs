using System.Threading.Tasks;
using Pic.Auth.Logic.Models;

namespace Pic.Auth.Logic.Interfaces.Services
{
    public interface IUserRegistrationValidationService
    {
        Task ValidateRegistrationFormAsync(RegisterUserModel registerUserModel);
    }
}