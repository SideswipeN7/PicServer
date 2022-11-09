namespace PS.Pictures.Application.Exceptions.Extensions;

internal static class FileNameNotUniqueExceptionExtensions
{
    public static void ThrowIfFilenameNotUnique(this string fileName, bool isUnique)
    {
        if (!isUnique)
        {
            throw new FileNameNotUniqueException(fileName);
        }
    }
}
