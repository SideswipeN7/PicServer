using Pic.Shared.Abstraction;
using System.Collections.Generic;

namespace Pic.Repository.Models
{
    public class UserEntity : DbEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<string>? Groups { get; set; }

        public override string? GetKey => Username;
    }
}