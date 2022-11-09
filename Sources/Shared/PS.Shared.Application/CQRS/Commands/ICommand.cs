using MediatR;

namespace PS.Shared.Application.CQRS.Commands;

public interface ICommand : IRequest
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
