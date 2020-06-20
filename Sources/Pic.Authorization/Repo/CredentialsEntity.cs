using Pic.Shared.Repository;

namespace Pic.Shared.Authorization.Repo
{
    public class CredentialsEntity : DbEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override string GetKey => Username;
    }
}