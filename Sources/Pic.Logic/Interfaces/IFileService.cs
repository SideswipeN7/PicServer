namespace Pic.Logic.Interfaces;

public interface IFileService
{
    void CreateDirectory(string path, string name);

    void CreateDirectory(string name);

    bool DeleteDirectory(string path, string name);

    bool DeleteDirectory(string folderName);
}
