using Pic.Data.Common;
using Pic.Data.Interfaces;

namespace Pic.Data.Entities;

public class PhotoAlbum : BaseEntity, IEntity
{
    public string Title { get; set; } = default!;

    public string FolderName { get; init; } = default!;

    public byte[]? Thumbnail { get; set; }

    public ICollection<Photo> Photos { get; set; } = default!;
}
