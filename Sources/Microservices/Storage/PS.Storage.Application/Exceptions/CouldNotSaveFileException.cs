namespace PS.Storage.Application.Exceptions;
internal class CouldNotSaveFileException : ApplicationException
{
    public CouldNotSaveFileException(string fileName)
        : base($"Could not save file {fileName}")
    {
    }
}
