using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Pic.Auth.Data.Entities;
using Pic.Auth.Logic.Interfaces.Services;

namespace Pic.Auth.Logic.Services
{
    public class JWTGenerationService : IJWTGenerationService
    {
        //TODO: GET FROM CONFIGURATION
        private const string isssuer = "ASdasda";

        private readonly IClaimResolverService claimResolverService = default!;

        public JWTGenerationService(IClaimResolverService claimResolverService)
        {
            this.claimResolverService = claimResolverService;
        }

        public string GenerateToken(ClientConfiguration clientConfiguration, IdentityUser user)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clientConfiguration.Secret));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(clientConfiguration.Claims.Select(c => claimResolverService.ResolveClaim(c, user))),
                Expires = DateTime.UtcNow.AddSeconds(clientConfiguration.TokenExpireInSeconds),
                Issuer = isssuer,
                Audience = clientConfiguration.Audience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha512),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}