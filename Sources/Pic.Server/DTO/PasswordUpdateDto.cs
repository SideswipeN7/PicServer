using System.ComponentModel.DataAnnotations;

namespace Pic.Server.DTO
{
    public class PasswordUpdateDto
    {
        [Required]
        public LoginDataDto loginData { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}