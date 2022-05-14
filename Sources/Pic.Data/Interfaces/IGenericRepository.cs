namespace Pic.Data.Interfaces;

public interface IGenericRepository<T>
    where T : class, IEntity
{
    Task<T?> FindAsync(int id, CancellationToken cancellationToken = default);

    IQueryable<T> Query();

    void Update(T entity);

    void UpdateRange(IEnumerable<T> entities);

    Task<T> Insert(T entity, CancellationToken cancellationToken = default);

    void Delete(T entity);

    void DeleteRange(IEnumerable<T> entities);

    Task SaveChanges(CancellationToken cancellationToken = default);
}
