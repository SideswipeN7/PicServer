using Pic.Domain.ValueObjects;

namespace Pic.Domain;

public interface IDomainEntity<ID, T>
    where T : IEntitySnapshot<T>
{
    T GetSnapshot();
}
