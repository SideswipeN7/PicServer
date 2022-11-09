namespace PS.Pictures.Infrastructure.EF.Models;

internal class BaseDbEntity
{
    public Guid Uid { get; set; }

    public long Id { get; set; }

    public DateTimeOffset CreateDate { get; set; }

    public DateTimeOffset UpdateDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public BaseDbEntity()
    {
        CreateDate = DateTimeOffset.Now;
        UpdateDate = DateTimeOffset.Now;
    }
}
