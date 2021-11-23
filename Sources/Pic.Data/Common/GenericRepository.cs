using Pic.Core.Infrastructure.Interfaces;

namespace Pic.Data.Common;

internal class GenericRepository<T> : IGenericRepository<T>
    where T : class, IEntity
{
    public DbContext DbContext { get; init; } = default!;

    protected DbSet<T> Context => DbContext.Set<T>();

    public Task<T?> FindAsync(int id, CancellationToken cancellationToken = default) => Context.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    public async Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Context.AddAsync(entity);
        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public IQueryable<T> Query() => Context.AsQueryable();

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        Context.Update(entity);

        return DbContext.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        Context.UpdateRange(entities);

        return DbContext.SaveChangesAsync(cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return DbContext.SaveChangesAsync(cancellationToken);
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        Context.RemoveRange(entities);

        return DbContext.SaveChangesAsync();
    }
}
