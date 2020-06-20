using System;

namespace Pic.Authorization.Models
    {
    public class AuthorizationResult
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}