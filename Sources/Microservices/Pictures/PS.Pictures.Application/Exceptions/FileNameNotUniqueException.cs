namespace PS.Pictures.Application.Exceptions;

public class FileNameNotUniqueException : ApplicationException
{
    public FileNameNotUniqueException(string fileName) : base($"File: {fileName} is not unique")
    {
    }
}
