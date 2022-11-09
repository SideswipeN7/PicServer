using Microsoft.Extensions.DependencyInjection;
using PS.Shared.Application.DI;

namespace PS.Pictures.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) => services.AddMessageBus(typeof(DependencyInjection).Assembly)
        .DecorateHandlersTransactional();
}
