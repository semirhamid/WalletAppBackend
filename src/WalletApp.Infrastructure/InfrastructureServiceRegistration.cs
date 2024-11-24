using Microsoft.Extensions.DependencyInjection;
using WalletApp.Application.Services;
using WalletApp.Infrastructure.Services;

namespace WalletApp.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IPointService, PointService>();
        return services;
    }
}
