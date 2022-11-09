using System.Text.RegularExpressions;

namespace PS.Pictures.Application.Extensions;

public static class StringExtensions
{
    private static readonly Regex BracketsRegex = new(@"/\(\d\)$");

    public static (string PureFileName, string Extension) GetFileNameWithExtension(this string fileName)
    {
        var typeSeparatorPosition = fileName.LastIndexOf(".", StringComparison.InvariantCulture);

        var filename = fileName[..typeSeparatorPosition];
        var extension = fileName.Substring(typeSeparatorPosition, fileName.Length);

        var match = BracketsRegex.Match(filename);

        var fileNameIndex = filename.LastIndexOf(match.Value, StringComparison.InvariantCulture);

        return new(filename[..fileNameIndex], extension);
    }
}
