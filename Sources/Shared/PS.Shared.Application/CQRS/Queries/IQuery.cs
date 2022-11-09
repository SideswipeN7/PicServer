using MediatR;

namespace PS.Shared.Application.CQRS.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
