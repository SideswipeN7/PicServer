using Pic.Shared.Data.Entities;

namespace Pic.Auth.Data.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = default!;

        public bool IsActive { get; set; }
    }
}