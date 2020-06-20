using System;
using Microsoft.AspNetCore.Mvc;
using Pic.Authorization.Services;
using Pic.Shared.Authorization.Models;

namespace Pic.Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly AuthorizationService authorizationService;

        public AuthorizationController(AuthorizationService authorizationService) => this.authorizationService = authorizationService;

        [HttpPut("Authorize")]
        public ActionResult<AuthorizationResult> AuthorizeByCredentials(Credentials credentials)
        {
            if (authorizationService.ValidateCredentails(credentials))
            {
                (string token, DateTime expireDate) = authorizationService.GenerateJWT(credentials);

                return Ok(new AuthorizationResult
                {
                    Token = token,
                    Expiry = expireDate
                });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("Register")]
        public ActionResult<bool> Register(Credentials credentials)
        {
            return Ok(authorizationService.RegisterCredentials(credentials));
        }
    }
}
