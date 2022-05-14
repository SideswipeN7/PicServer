using Pic.Domain.ValueObjects;

namespace Pic.Domain;

public interface IAggregate<ID, T> : IDomainEntity<ID, T>
    where T : IEntitySnapshot<T>
{
}
