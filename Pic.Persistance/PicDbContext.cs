using Microsoft.EntityFrameworkCore;
using Pic.Data.Models;
using Pic.Persistance.Generators;

namespace Pic.Persistance;

public class PicDbContext : DbContext
{
    public DbSet<PhotoAlbum> PhotoAlbums { get; set; } = default!;

    public DbSet<Photo> Photos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<BaseModel>()
            .Property(bm => bm.UpdateDate)
            .HasValueGenerator<DateTimeOffsetGenerator>()
            .ValueGeneratedOnAddOrUpdate();

        modelBuilder
            .Entity<BaseModel>()
            .Property(bm => bm.CreateDate)
            .HasValueGenerator<DateTimeOffsetGenerator>()
            .ValueGeneratedOnAdd();

        base.OnModelCreating(modelBuilder);
    }
}
