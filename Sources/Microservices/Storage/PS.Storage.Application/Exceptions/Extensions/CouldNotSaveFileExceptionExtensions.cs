namespace PS.Storage.Application.Exceptions.Extensions;

internal static class CouldNotSaveFileExceptionExtensions
{
    public static void ThrowIfNotSaved(this bool isFileSaved, string fileName)
    {
        if (!isFileSaved)
        {
            throw new CouldNotSaveFileException(fileName);
        }
    }
}
