namespace Pic.Auth.Logic.Interfaces.Services
{
    public interface IPasswordService
    {
        public string CreatePasswordHash(string password);

        bool IsSamePassword(string passwordHash, string password);
    }
}