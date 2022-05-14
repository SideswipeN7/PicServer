

using Pic.Core.Infrastructure.Constants;

namespace Pic.Data.Entities;

public class PhotoAlbum : BaseEntity, IEntity
{
    [MaxLength(StringConstrains.MaxTitleLength)]
    public string Title { get; set; } = default!;

    public string DirectoryName { get; init; } = default!;

    [MaxLength(StringConstrains.MaxSynopsisLength)]
    public string? Synopsis { get; init; }

    public byte[]? Thumbnail { get; set; }

    public ICollection<Photo> Photos { get; set; } = default!;
}
