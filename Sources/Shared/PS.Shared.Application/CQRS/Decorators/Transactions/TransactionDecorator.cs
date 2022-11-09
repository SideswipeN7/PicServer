using MediatR;

namespace PS.Shared.Application.CQRS.Decorators.Transactions;

internal class TransactionDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ITransactionService transactionService;
    private readonly IRequestHandler<TRequest, TResponse> handler;

    public TransactionDecorator(ITransactionService transactionService, IRequestHandler<TRequest, TResponse> handler)
    {
        this.transactionService = transactionService;
        this.handler = handler;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var transaction = transactionService.BeginTransaction();

        try
        {
            var result = await handler.Handle(request, cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return result;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            throw;
        }
    }
}
