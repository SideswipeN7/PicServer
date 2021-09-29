using System.Reflection;
using Pic.Logic.Interfaces;

namespace Pic.Logic.Services;

public class FileService : IFileService
{
    public void CreateFolder(string path, string name)
    {
        var fullPath = Path.Combine(path, name);

        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
        }
    }

    public void CreateFolder(string name)
    {
        var baseFolder = GetBaseFolderPath();

        CreateFolder(baseFolder, name);
    }

    public bool RemoveFolder(string folderName)
    {
        var baseFolder = GetBaseFolderPath();

        return RemoveFolder(baseFolder, folderName);
    }

    public bool RemoveFolder(string path, string name)
    {
        var fullPath = Path.Combine(path, name);

        if (!Directory.Exists(fullPath))
        {
            return true;
        }

        return SecureDeleteDirectory(fullPath);
    }

    private static bool SecureDeleteDirectory(string fullPath)
    {
        try
        {
            Directory.Delete(fullPath, true);

            return false;
        }
        catch
        {
            return false;
        }
    }

    private static string GetBaseFolderPath()
    {
        var executionFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        return Path.Combine(executionFolder, "..", "..", "..", "..", "Data");
    }
}
