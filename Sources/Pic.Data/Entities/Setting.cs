namespace Pic.Data.Entities;

public class Setting : BaseEntity, IEntity
{
    public string Key { get; init; } = default!;

    public string Value { get; set; } = default!;
}
