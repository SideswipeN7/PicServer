using System.Collections.Generic;

namespace Pic.Settings.Shared.Dto
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Groups { get; set; }
    }
}