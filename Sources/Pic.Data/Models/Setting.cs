using Pic.Data.Interfaces;

namespace Pic.Data.Models;

public class Setting : BaseModel, IEntity
{
    public string Key { get; init; } = default!;

    public string Value { get; set; } = default!;
}
