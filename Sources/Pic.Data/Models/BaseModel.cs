namespace Pic.Data.Models;

public class BaseModel
{
    public int Id { get; set; }

    public DateTimeOffset CreateDate { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset UpdateDate { get; set; } = DateTimeOffset.UtcNow;

    public bool IsDeleted { get; private set; }

    public void MarkAsDeleted()
    {
        IsDeleted = true;
        UpdateModelDate();
    }

    protected void UpdateModelDate() => UpdateDate = DateTimeOffset.UtcNow;
}
