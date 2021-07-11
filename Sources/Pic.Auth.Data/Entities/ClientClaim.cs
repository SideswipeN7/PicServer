using Pic.Shared.Data.Entities;

namespace Pic.Auth.Data.Entities
{
    public class ClientClaim : BaseEntity
    {
        public string Name { get; set; } = default!;
    }
}