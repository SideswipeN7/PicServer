namespace PS.Shared.Domain.Domain.Exceptions;

public class EmptyStringException : DomainException
{
    public EmptyStringException(string variableName)
        : base($"{variableName} is empty!")
    {
    }
}
