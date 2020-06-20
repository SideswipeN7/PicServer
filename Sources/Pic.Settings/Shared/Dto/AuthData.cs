using System.ComponentModel.DataAnnotations;

namespace Pic.Settings.Shared.Dto
{
    public class CredentialsDto
    {
        [Required]
        [MinLength(4)]
        public string Username { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}