namespace Pic.Persistance.Contextes;

internal class MigrationContext : PicDbContext
{
    public MigrationContext() : base(new DbContextOptionsBuilder().Options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer();
    }
}

