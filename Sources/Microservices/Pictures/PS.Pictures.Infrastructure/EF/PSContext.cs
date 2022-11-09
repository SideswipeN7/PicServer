using Microsoft.EntityFrameworkCore;
using PS.Pictures.Infrastructure.EF.Models;

namespace PS.Pictures.Infrastructure.EF;

internal class PSContext : DbContext
{
    internal DbSet<PictureDbModel> Pictures => Set<PictureDbModel>();

    public PSContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PSContext).Assembly);
    }
}
