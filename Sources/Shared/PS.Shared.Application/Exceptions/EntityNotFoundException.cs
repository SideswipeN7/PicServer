namespace PS.Shared.Application.Exceptions;

public sealed class EntityNotFoundException : ApplicationException
{
    public EntityNotFoundException(Guid guid)
        : base($"Guid: '{guid}' is Empty!")
    {
    }
}
