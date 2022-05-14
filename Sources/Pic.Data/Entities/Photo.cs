namespace Pic.Data.Entities;

public class Photo : BaseEntity, IEntity
{
    public string Name { get; set; } = null!;

    public string FileName { get; init; } = null!;

    public byte[] Thumbnail { get; init; } = null!;

    public int PhotoAlbumId { get; set; }

    public PhotoAlbum PhotoAlbum { get; set; } = null!;
}
