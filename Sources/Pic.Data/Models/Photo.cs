using Pic.Data.Interfaces;

namespace Pic.Data.Models;

public class Photo : BaseModel, IEntity
{
    public string Name { get; private set; } = default!;

    public string FileName { get; init; } = default!;

    public byte[] Thumbnail { get; init; } = default!;

    public int PhotoAlbumId { get; set; }

    public PhotoAlbum PhotoAlbum { get; set; } = default!;

    public void ChangeTitle(string newName)
    {
        Name = newName;
        UpdateModel();
    }
}
