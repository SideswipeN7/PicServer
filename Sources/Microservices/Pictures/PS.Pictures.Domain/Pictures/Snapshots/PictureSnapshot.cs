namespace PS.Pictures.Domain.Pictures.Snapshots;

public record PictureSnapshot(Guid Uid, string Owner, string FileName, string? Name, string? Description, string Location)
{
    internal PictureState AsState() => new(FileName, Name, Description);
}
