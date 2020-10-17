using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pic.Database.Data.Entities;
using Pic.Database.Interfaces;

namespace Pic.Database
{
    public class GenericDbContext : DbContext, IContext
    {
        private readonly IEntityTypeConfiguration<BaseEntity>[] entityTypeConfigurations;

        public GenericDbContext(DbContextOptions<DbContext> dbContextOptions, params IEntityTypeConfiguration<BaseEntity>[] entityTypeConfigurations) : base(dbContextOptions) =>
            this.entityTypeConfigurations = entityTypeConfigurations;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach(var entityTypeConfiguration in entityTypeConfigurations)
            {
                modelBuilder.ApplyConfiguration(entityTypeConfiguration);
            }
        }

        public DbSet<T> GetDbSet<T>() where T : BaseEntity => Set<T>();

        public async Task<int> SaveChangesAsync() => await SaveChangesAsync();
    }
}