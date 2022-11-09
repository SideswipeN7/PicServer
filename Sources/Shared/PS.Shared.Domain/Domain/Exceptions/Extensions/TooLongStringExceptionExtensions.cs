using System.Runtime.CompilerServices;
using PS.Shared.Domain.ValueObjects;

namespace PS.Shared.Domain.Domain.Exceptions.Extensions;

public static class TooLongStringExceptionExtensions
{
    public static void ThrowIfLongerThan(this string? variable, int maxLength, [CallerArgumentExpression("variable")] string variableName = "")
    {
        if (variable?.Length > maxLength)
        {
            throw new TooLongStringException(variableName, maxLength);
        }
    }
    
    public static void ThrowIfLongerThan(this StringTrimValue variable, int maxLength, [CallerArgumentExpression("variable")] string variableName = "")
    {
        if (variable.Length > maxLength)
        {
            throw new TooLongStringException(variableName, maxLength);
        }
    }
    
    public static void ThrowIfLongerThan(this OptionalStringTrimValue variable, int maxLength, [CallerArgumentExpression("variable")] string variableName = "")
    {
        if (variable.Length > maxLength)
        {
            throw new TooLongStringException(variableName, maxLength);
        }
    }
}
