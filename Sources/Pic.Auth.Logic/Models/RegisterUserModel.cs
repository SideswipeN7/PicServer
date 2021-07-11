namespace Pic.Auth.Logic.Models
{
    public record RegisterUserModel
    {
        public string UserName { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string RepeatedPassword { get; set; } = default!;
    }
}