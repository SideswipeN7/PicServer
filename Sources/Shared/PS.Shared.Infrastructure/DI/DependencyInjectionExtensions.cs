using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace PS.Shared.Infrastructure.DI;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, Assembly assembly)
    {
        var repositories = assembly
            .DefinedTypes
            .Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith("Repository"))
            .Select(x => new { concreteType = x, interfaceType = x.GetInterfaces().First() })
            .ToList();

        foreach (var repo in repositories)
        {
            services.TryAddScoped(repo.interfaceType, repo.concreteType);
        }

        return services;
    }
}
