using System;

namespace Pic.Shared.Authorization.Models
{
    public class AuthorizationResult
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}