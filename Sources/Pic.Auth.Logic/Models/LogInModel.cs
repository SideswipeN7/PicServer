namespace Pic.Auth.Logic.Models
{
    public record LogInModel
    {
        public string ClientId { get; set; } = default!;

        public string UserName { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}