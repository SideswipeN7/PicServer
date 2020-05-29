using System.Collections.Generic;

namespace Pic.Settings.Shared.Models
{
    public class UserData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Groups { get; set; }
    }
}