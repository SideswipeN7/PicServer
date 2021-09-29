namespace Pic.Data.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class, IEntity
{
    Task<T?> FindAsync(int id, CancellationToken cancellationToken = default);

    IQueryable<T> Query();

    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

    Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default);
}
