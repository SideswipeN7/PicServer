using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pic.Shared.Data.Entities;
using Pic.Shared.Data.Interfaces;

namespace Pic.Shared.Data.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext dbContext;
        protected readonly DbSet<T> context;

        protected GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            context = dbContext.Set<T>();
        }

        public EntityEntry<T> Add(T entity) => context.Add(entity);

        public ValueTask<EntityEntry<T>> AddAsync(T entity, CancellationToken cancellationToken = default) => context.AddAsync(entity, cancellationToken);

        public EntityEntry<T> Delete(int id)
        {
            var entity = context.Find(id);

            return context.Remove(entity);
        }

        public EntityEntry<T> Delete(T entity) => context.Remove(entity);

        public async ValueTask<EntityEntry<T>> DeleteAsync(int id)
        {
            var entity = await context.FindAsync(id);

            return context.Remove(entity);
        }

        public void DeleteRange(params T[] entities) => context.RemoveRange(entities);

        public T Find(int id) => context.Find(id);

        public ValueTask<T> FindAsync(int id) => context.FindAsync(id);

        public IEnumerable<T> GetAll() => context.ToList();

        public IAsyncEnumerable<T> GetAllAsync() => context.AsAsyncEnumerable();

        public EntityEntry<T> Update(T entity) => context.Update(entity);

        public void UpdateRange(params T[] entities) => context.UpdateRange(entities);

        public IQueryable<T> Query() => context.AsQueryable();

        public int SaveChanges() => dbContext.SaveChanges();

        public int SaveChanges(bool acceptAllChangesOnSuccess) => dbContext.SaveChanges(acceptAllChangesOnSuccess);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => dbContext.SaveChangesAsync(cancellationToken);

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) => dbContext.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}