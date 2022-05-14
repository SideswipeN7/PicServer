namespace Pic.Core.Logic.Services;

internal class FileService : IFileService
{
    public bool CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            return Directory.CreateDirectory(path).Exists;
        }

        return true;
    }

    public bool DeleteDirectory(string path, bool isRecursive = true)
    {
        Directory.Delete(path, isRecursive);

        return true;
    }

    public bool SecureDeleteDirectory(string path, bool isRecursive = true)
    {
        try
        {
            return DeleteDirectory(path, isRecursive);
        }
        catch
        {
            return false;
        }
    }
}
