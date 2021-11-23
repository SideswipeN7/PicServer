using Pic.Core.Infrastructure.Interfaces;

namespace Pic.Core.Infrastructure.Models;

public class Photo : BaseEntity, IEntity
{
    public string Name { get; private set; } = default!;

    public string FileName { get; init; } = default!;

    public byte[] Thumbnail { get; init; } = default!;

    public int PhotoAlbumId { get; set; }

    public PhotoAlbum PhotoAlbum { get; set; } = default!;
}
