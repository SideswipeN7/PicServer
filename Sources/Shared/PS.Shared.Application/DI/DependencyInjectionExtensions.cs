using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PS.Shared.Application.CQRS.Decorators.Transactions;

namespace PS.Shared.Application.DI;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection DecorateHandlersTransactional(this IServiceCollection services) => services.Decorate(typeof(IRequestHandler<,>), typeof(TransactionDecorator<,>));

    public static IServiceCollection AddMessageBus(this IServiceCollection services, Assembly assembly) => services.AddMediatR(assembly);
}
