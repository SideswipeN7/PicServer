namespace PS.Storage.Application.Exceptions;
internal class FileNotFoundException : ApplicationException
{
    public FileNotFoundException(string fileName)
        : base($"Could not find file {fileName}")
    {
    }
}
