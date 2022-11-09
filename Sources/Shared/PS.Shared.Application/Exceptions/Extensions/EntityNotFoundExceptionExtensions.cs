namespace PS.Shared.Application.Exceptions.Extensions;

public static class EntityNotFoundExceptionExtensions
{
    public static void ThrowIfNotFound<T>(this T? entity, Guid uid)
        where T : class
    {
        if (entity is null)
        {
            throw new EntityNotFoundException(uid);
        }
    }
}
