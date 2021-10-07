namespace Pic.Logic.Interfaces;

public interface IFileService
{
    bool CreateDirectory(string path);

    bool DeleteDirectory(string path, bool isRecursive = true);

    bool SecureDeleteDirectory(string path, bool isRecursive = true);
}
