namespace PS.Storage.Application.Exceptions.Extensions;

internal static class FileNotFoundExceptionExtensions
{
    public static void ThrowIfNotFound(this byte[]? fileBytes, string fileName)
    {
        if (fileBytes is null)
        {
            throw new FileNotFoundException(fileName);
        }
    }
}
