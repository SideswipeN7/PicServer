using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pic.Shared.Data.Entities;

namespace Pic.Shared.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        EntityEntry<T> Add(T entity);
        ValueTask<EntityEntry<T>> AddAsync(T entity, CancellationToken cancellationToken = default);

        EntityEntry<T> Delete(int id);
        EntityEntry<T> Delete(T entity);
        ValueTask<EntityEntry<T>> DeleteAsync(int id);
        void DeleteRange(params T[] entities);

        T Find(int id);
        ValueTask<T> FindAsync(int id);

        IEnumerable<T> GetAll();
        IAsyncEnumerable<T> GetAllAsync();

        EntityEntry<T> Update(T entity);
        void UpdateRange(params T[] entities);

        IQueryable<T> Query();

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}