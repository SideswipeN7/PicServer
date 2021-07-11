using System.Threading.Tasks;
using Pic.Auth.Data.Entities;
using Pic.Auth.Logic.Models;

namespace Pic.Auth.Logic.Interfaces.Services
{
    public interface IUserLogInValidationService
    {
        Task ValidateLogInAttemptAndSetUserFlagsAsync(IdentityUser? user, LogInModel loginModel);
    }
}