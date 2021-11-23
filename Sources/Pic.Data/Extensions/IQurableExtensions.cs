namespace Pic.Data.Extensions;

internal static class IQurableExtensions
{
    public static IQueryable<T> OnlyActive<T>(this IQueryable<T> query)
        where T : BaseEntity
        => query.Where(x => !x.IsDeleted);
}
