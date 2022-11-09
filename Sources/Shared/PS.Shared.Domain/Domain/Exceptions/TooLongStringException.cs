namespace PS.Shared.Domain.Domain.Exceptions;

public class TooLongStringException : DomainException
{
    public TooLongStringException(string variableName, int maxLength)
        : base($"Variable: '{variableName}' is longer than max allowed: {maxLength}!")
    {
    }
}
