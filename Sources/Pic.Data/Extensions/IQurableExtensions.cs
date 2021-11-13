using Pic.Data.Common;

namespace Pic.Data.Extensions;

internal static class IQurableExtensions
{
    public static IQueryable<T> OnlyActive<T>(this IQueryable<T> query)
        where T : BaseEntity
        => query.Where(x => !x.IsDeleted);

    public static Task<T?> FirstOrNullAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        where T : IEntity
    {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
        return query.FirstOrDefaultAsync(expression, cancellationToken);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
    }

    public static Task<T?> FirstOrNullAsync<T>(this IQueryable<T> query, int id, CancellationToken cancellationToken = default)
        where T : IEntity
        => query.FirstOrNullAsync(x => x.Id == id, cancellationToken);
}
