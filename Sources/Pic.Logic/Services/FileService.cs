using System.Reflection;
using Pic.Logic.Interfaces;

namespace Pic.Logic.Services;

public class FileService : IFileService
{
    public void CreateDirectory(string path, string name)
    {
        var fullPath = Path.Combine(path, name);

        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
        }
    }

    public void CreateDirectory(string name)
    {
        var baseFolder = GetBaseFolderPath();

        CreateDirectory(baseFolder, name);
    }

    public bool DeleteDirectory(string folderName)
    {
        var baseFolder = GetBaseFolderPath();

        return DeleteDirectory(baseFolder, folderName);
    }

    public bool DeleteDirectory(string path, string name)
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

            return true;
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
