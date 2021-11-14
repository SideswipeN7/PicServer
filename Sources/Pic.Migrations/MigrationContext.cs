namespace Pic.Persistance.Contextes;

internal class MigrationContext : PicDbContext
{
    public MigrationContext()
        : base(new DbContextOptionsBuilder().UseSqlServer().Options)
    {
    }

    public MigrationContext(string connectionString)
        : base(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
    {
    }
}
