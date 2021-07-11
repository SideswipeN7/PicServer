using System.Collections.Generic;
using Pic.Shared.Data.Entities;

namespace Pic.Auth.Data.Entities
{
    public class ClientConfiguration : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string Audience { get; set; } = default!;

        public string Secret { get; set; } = default!;

        public string ClientId { get; set; } = default!;

        public long TokenExpireInSeconds { get; set; }

        public IEnumerable<ClientClaim> Claims = default!;
    }
}