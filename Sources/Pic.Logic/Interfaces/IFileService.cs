namespace Pic.Logic.Interfaces;

public interface IFileService
{
    void CreateFolder(string path, string name);

    void CreateFolder(string name);

    bool RemoveFolder(string path, string name);

    bool RemoveFolder(string folderName);
}
