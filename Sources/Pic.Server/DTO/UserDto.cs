using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pic.Server.DTO
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MinLength(1)]
        public List<string> Groups { get; set; }
    }
}