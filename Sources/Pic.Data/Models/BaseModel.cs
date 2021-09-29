namespace Pic.Data.Models;

public class BaseModel
{
    public int Id { get; set; }

    public DateTimeOffset CreateDate { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset UpdateDate { get; set; } = DateTimeOffset.UtcNow;

    public bool IsDeleted { get; private set; }

    public void MarkAsDeleted() => IsDeleted = true;

    //protected void UpdateModel<T>(Action<T> updateFunc) where T : BaseModel
    //{
    //    updateFunc((T)this);
    //    UpdateDate = DateTimeOffset.UtcNow;
    //}
}
