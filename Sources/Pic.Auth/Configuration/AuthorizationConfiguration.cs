namespace Pic.Auth.Configuration
{
    using IdentityServer4.EntityFramework.Entities;

    public class AuthorizationConfiguration
    {
        public ApiScope[] ApiScopes { get; set; }

        public Client[] Clients { get; set; }
    }
}