using System.Data.Common;

namespace PS.Shared.Application.CQRS.Decorators.Transactions;

public interface ITransactionService
{
    DbTransaction BeginTransaction();
}
