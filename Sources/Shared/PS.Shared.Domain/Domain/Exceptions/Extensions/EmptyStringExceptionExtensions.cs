using System.Runtime.CompilerServices;

namespace PS.Shared.Domain.Domain.Exceptions.Extensions;

public static class EmptyStringExceptionExtensions
{
    public static string? ThrowIfNullOrDefault(this string? variable, [CallerArgumentExpression("variable")] string variableName = "")
    {
        if (string.IsNullOrWhiteSpace(variable))
        {
            throw new EmptyStringException(variableName);
        }

        return variable;
    }
}
