namespace Pic.Core.Infrastructure.Models;

public class AlbumInfo
{
    public int Id { get; set; }

    public string Title { get; set; } = default!;

    public byte[] Thumbnail { get; set; } = default!;

    public int PhotosCount { get; set; }
}
