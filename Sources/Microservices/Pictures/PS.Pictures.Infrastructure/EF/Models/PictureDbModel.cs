namespace PS.Pictures.Infrastructure.EF.Models;

internal class PictureDbModel : BaseDbEntity
{
    public string Name { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string? Description { get; set; }

    public string Location { get; set; } = null!;

    public bool IsArchived { get; set; }

    public string Owner { get; set; } = null!;

    public DateTimeOffset? ArchivedTime { get; set; }

    public byte[] Miniature { get; set; } = null!;
}
