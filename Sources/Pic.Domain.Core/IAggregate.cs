using Pic.Domain.Core.ValueObjects;

namespace Pic.Domain.Core;

public interface IAggregate<ID, T> : IDomainEntity<ID, T>
    where T : IEntitySnapshot<T>
{
}
