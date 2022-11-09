using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PS.Pictures.Infrastructure.EF;
using PS.Shared.Infrastructure.DI;

namespace PS.Pictures.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PSContext>(options => options.UseSqlServer(configuration.GetConnectionString("PS")));

        services.AddRepositories(typeof(DependencyInjection).Assembly);

        return services;
    }
}
