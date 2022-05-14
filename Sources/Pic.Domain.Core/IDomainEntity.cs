using Pic.Domain.Core.ValueObjects;

namespace Pic.Domain.Core;

public interface IDomainEntity<ID, T>
    where T : IEntitySnapshot<T>
{
    T GetSnapshot();
}
