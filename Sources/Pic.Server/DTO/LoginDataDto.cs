using System.ComponentModel.DataAnnotations;

namespace Pic.Server.DTO
{
    public class LoginDataDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}