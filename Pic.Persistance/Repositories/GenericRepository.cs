using Microsoft.EntityFrameworkCore;
using Pic.Data.Interfaces;
using Pic.Data.Interfaces.Repositories;

namespace Pic.Persistance.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    private DbContext DbContext { get; init; } = default!;

    protected DbSet<T> Context => DbContext.Set<T>();

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
    public Task<T?> FindAsync(int id, CancellationToken cancellationToken = default) => Context.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.

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
}
