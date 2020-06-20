using System.ComponentModel.DataAnnotations;

namespace Pic.Shared.Authorization.Models
{
    public class Credentials
    {
        [Required]
        [MinLength(4)]
        public string Username { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}