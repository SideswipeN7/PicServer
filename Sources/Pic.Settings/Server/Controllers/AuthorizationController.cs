using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pic.Settings.Server.Services;
using Pic.Settings.Shared.Dto;

namespace Pic.Settings.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly AuthorizationService authorization;

        public AuthorizationController(AuthorizationService authorization) => this.authorization = authorization;

        [HttpPut]
        [Route("Login")]
        public async Task<LogInResultDto> LogIn(CredentialsDto credentials)
        {
            return await authorization.LogIn(credentials);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<bool> Register(CredentialsDto credentials)
        {
            return await authorization.Register(credentials);
        }
    }
}