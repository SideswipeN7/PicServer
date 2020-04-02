using System.Collections.Generic;

namespace Pic.Shared.Models
{
    public class User
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<string>? Groups { get; set; }
    }
}