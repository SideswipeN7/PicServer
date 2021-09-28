using Microsoft.EntityFrameworkCore;
using Pic.Data.Interfaces;
using Pic.Data.Interfaces.Repositories;

namespace Pic.Persistance.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    private DbContext DbContext { get; init; } = default!;

    protected DbSet<T> Context => DbContext.Set<T>();

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
    public Task<T?> FindAsync(int id) => Context.FirstOrDefaultAsync(e => e.Id == id);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.

    public async Task<T> InsertAsync(T entity)
    {
        await Context.AddAsync(entity);
        await DbContext.SaveChangesAsync();

        return entity;
    }

    public IQueryable<T> Query() => Context.AsQueryable();

    public Task UpdateAsync(T entity)
    {
        Context.Update(entity);

        return DbContext.SaveChangesAsync();
    }
}
