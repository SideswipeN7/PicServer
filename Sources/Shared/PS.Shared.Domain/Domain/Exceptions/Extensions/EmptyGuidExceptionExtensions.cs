namespace PS.Shared.Domain.Domain.Exceptions.Extensions;

public static class EmptyGuidExceptionExtensions
{
    public static void ThrowIfDefault(this Guid uid)
    {
        if (uid == Guid.Empty)
        {
            throw new EmptyGuidException(uid);
        }
    }
}
