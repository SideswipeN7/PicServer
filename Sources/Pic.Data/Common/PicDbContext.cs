namespace Pic.Data.Common;

public class PicDbContext : DbContext
{
    public DbSet<PhotoAlbum> PhotoAlbums { get; set; } = default!;

    public DbSet<Photo> Photos { get; set; } = default!;

    public DbSet<Setting> Settings { get; set; } = default!;

    public PicDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {
    }

    public override int SaveChanges()
    {
        UpdateChanges();

        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        UpdateChanges();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateChanges();

        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        UpdateChanges();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PicDbContext).Assembly);
    }

    private void UpdateChanges()
    {
        var entries = ChangeTracker
           .Entries()
           .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdateDate = DateTimeOffset.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreateDate = DateTimeOffset.UtcNow;
            }
        }
    }
}
