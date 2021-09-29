using System.Reflection;
using Pic.Logic.Interfaces;

namespace Pic.Logic.Services;

public class FileService : IFileService
{
    public void CreateFolder(string name, string path)
    {
        var fullPath = Path.Combine(path, name);

        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
        }
    }

    public void CreateFolder(string name)
    {
        var executionFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        var baseFolder = Path.Combine(executionFolder, "..", "..", "..", "..", "Data");

        CreateFolder(baseFolder, name);
    }
}
