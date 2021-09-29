namespace Pic.Data.Models;

public abstract class BaseModel
{
    public int Id { get; set; }

    public DateTimeOffset CreateDate { get; set; }

    public DateTimeOffset UpdateDate { get; set; }

    public bool IsDeleted { get; private set; }

    public void MarkAsDeleted() => IsDeleted = true;

    public void Restore() => IsDeleted = false;
}
