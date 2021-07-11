using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pic.Auth.Logic.Models;
using Pic.Auth.Logic.UseCases;

namespace Pic.Auth.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly UserLogsInUsingClientIdUseCase userLogsInUsingClientIdUseCase;

        public AuthorizationController(UserLogsInUsingClientIdUseCase userLogsInUsingClientIdUseCase) => this.userLogsInUsingClientIdUseCase = userLogsInUsingClientIdUseCase;

        [HttpPost]
        public Task<string> AutheticateAsync(LogInModel logInModel) => userLogsInUsingClientIdUseCase.LogInAsync(logInModel);
    }
}