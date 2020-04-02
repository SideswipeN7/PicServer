using Pic.Shared.Abstraction;
using Pic.Shared.Models;

namespace Pic.Repository.Models
{
    public class GroupEntity : DbEntity
    {
        public string? Name { get; set; }
        public Rights Rights { get; set; }

        public override string? GetKey => Name;
    }
}