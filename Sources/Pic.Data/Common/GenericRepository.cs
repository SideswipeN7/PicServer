namespace Pic.Data.Common;

internal class GenericRepository<T> : IGenericRepository<T>
    where T : class, IEntity
{
    public DbContext DbContext { get; init; } = default!;

    protected DbSet<T> Context => DbContext.Set<T>();

    public Task<T?> FindAsync(int id, CancellationToken cancellationToken = default) => Context.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    public async Task<T> Insert(T entity, CancellationToken cancellationToken = default) => (await Context.AddAsync(entity, cancellationToken)).Entity;

    public IQueryable<T> Query() => Context.AsQueryable();

    public void Update(T entity) => Context.Update(entity);

    public void UpdateRange(IEnumerable<T> entities) => Context.UpdateRange(entities);

    public Task SaveChanges(CancellationToken cancellationToken = default) => DbContext.SaveChangesAsync(cancellationToken);

    public void DeleteRange(IEnumerable<T> entities) => Context.RemoveRange(entities);

    public void Delete(T entity) => Context.Remove(entity);
}
