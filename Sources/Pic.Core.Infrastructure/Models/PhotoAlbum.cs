using System.ComponentModel.DataAnnotations;
using Pic.Core.Infrastructure.Interfaces;
using Pic.Core.Shared.Constants;

namespace Pic.Core.Infrastructure.Models;

public class PhotoAlbum : BaseEntity, IEntity
{
    [MaxLength(StringConstrains.MaxTitleLength)]
    public string Title { get; set; } = default!;

    public string FolderName { get; init; } = default!;

    [MaxLength(StringConstrains.MaxSynopsisLength)]
    public string? Synopsis { get; init; }

    public byte[]? Thumbnail { get; set; }

    public ICollection<Photo> Photos { get; set; } = default!;
}
