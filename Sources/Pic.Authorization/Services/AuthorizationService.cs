using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Pic.Authorization.Configuration;
using Pic.Shared.Authorization.Models;
using Pic.Shared.Authorization.Repo;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pic.Authorization.Services
{
    public class AuthorizationService
    {
        private readonly JwtConfiguration jwtConfiguration;
        private readonly CredentialsRepository credentialsRepository;
        private readonly PasswordHasher<string> passwordHasher;
        private readonly JwtSecurityTokenHandler tokenHandler;
        private readonly SymmetricSecurityKey securityKey;

        public AuthorizationService(JwtConfiguration jwtConfiguration, CredentialsRepository credentialsRepository)
        {
            this.jwtConfiguration = jwtConfiguration;
            this.credentialsRepository = credentialsRepository;
            passwordHasher = new PasswordHasher<string>();
            tokenHandler = new JwtSecurityTokenHandler();
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key));
        }

        public bool RegisterCredentials(Credentials credentials)
        {
            if (credentialsRepository.CheckIfExists(x => x.Username == credentials.Username))
            {
                return false;
            }

            credentialsRepository.Add(new CredentialsEntity
            {
                Username = credentials.Username,
                Password = passwordHasher.HashPassword(credentials.Username, credentials.Password)
            });

            return true;
        }

        public bool ValidateCredentails(Credentials credentials)
        {
            CredentialsEntity credentialsEntity = credentialsRepository.FirstOrDefault(x => x.Username == credentials.Username);
            if (credentialsEntity is null)
            {
                return false;
            }

            return passwordHasher.VerifyHashedPassword(credentialsEntity.Username, credentialsEntity.Password, credentials.Password) == PasswordVerificationResult.Success;
        }

        public (string, DateTime) GenerateJWT(Credentials credentials)
        {
            var expireDate = DateTime.Now.AddDays(jwtConfiguration.Expiry);
            string token = tokenHandler.WriteToken(new JwtSecurityToken(
                   jwtConfiguration.Issuer,
                   jwtConfiguration.Audience,
                   new[] { new Claim(ClaimTypes.Name, credentials.Username) },
                   expires: expireDate,
                   signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                   ));

            return (token, expireDate);
        }
    }
}
