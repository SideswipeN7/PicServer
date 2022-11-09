using Microsoft.Extensions.DependencyInjection;
using PS.Shared.Application.DI;

namespace PS.Storage.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) => services.AddMessageBus(typeof(DependencyInjection).Assembly);
}
