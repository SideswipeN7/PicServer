using Microsoft.EntityFrameworkCore;
using Pic.Database;
using Pic.Database.Entities;

namespace Pic.Service.Database
{
    public class AppDbContext : GenericDbContext
    {
        public AppDbContext(DbContextOptions<DbContext> dbContextOptions, params IEntityTypeConfiguration<BaseEntity>[] entityTypeConfigurations)
            : base(dbContextOptions, entityTypeConfigurations)
        { }
    }
}