using Pic.Shared.Authorization.Configuration;
using Pic.Shared.Repository;

namespace Pic.Shared.Authorization.Repo
{
    public class CredentialsRepository : LiteDbRepository<CredentialsEntity> {
        public CredentialsRepository(DbConfiguration dbConfiguration) : base(dbConfiguration.Path) { }
    }
}