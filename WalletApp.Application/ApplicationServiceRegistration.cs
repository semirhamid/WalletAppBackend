using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace WalletApp.Application;

public static class ApplicationServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // services.AddMediatR(Assembly.GetExecutingAssembly());
    }
    
}