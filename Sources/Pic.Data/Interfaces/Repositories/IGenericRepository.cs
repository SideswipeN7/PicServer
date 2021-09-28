namespace Pic.Data.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class, IEntity
{
    Task<T?> FindAsync(int id);

    IQueryable<T> Query();

    Task UpdateAsync(T entity);

    Task<T> InsertAsync(T entity);
}
