using Pic.Core.Infrastructure.Interfaces;

namespace Pic.Core.Infrastructure.Models;

public class Setting : BaseEntity, IEntity
{
    public string Key { get; init; } = default!;

    public string Value { get; set; } = default!;
}
