using Pic.Auth.Logic.Interfaces.Services;

namespace Pic.Auth.Logic.Services
{
    public class PasswordService : IPasswordService
    {
        //TODO: Move to configuration file
        private const string Salt = "134wd#@(UI)(!J@";

        private readonly IHashService hashService;

        public PasswordService(IHashService hashService)
        {
            this.hashService = hashService;
        }

        public string CreatePasswordHash(string password) => hashService.Hash(Salt + password);

        public bool IsSamePassword(string passwordHash, string password) => CreatePasswordHash(password) == passwordHash;
    }
}