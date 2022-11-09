using System.Runtime.Serialization;

namespace PS.Shared.Domain.Domain.Exceptions;

public sealed class EmptyGuidException : DomainException
{
    public EmptyGuidException(Guid guid)
        : base($"Guid: '{guid}' is Empty!")
    {
    }
}
