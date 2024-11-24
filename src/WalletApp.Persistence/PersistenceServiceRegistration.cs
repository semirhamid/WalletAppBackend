using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WalletApp.Application.Contracts.Persistence;
using WalletApp.Infrastructure.Persistence.Options;
using WalletApp.Infrastructure.Persistence.Reporsitories;

namespace WalletApp.Infrastructure.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();
        services.AddDbContext<WalletAppDbContext>((serviceProvider, databaseContextOptionBuilder) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;
            databaseContextOptionBuilder.UseNpgsql(databaseOptions.ConnectionString, options =>
            {
                options.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                options.CommandTimeout(databaseOptions.CommandTimeout);
            });
            databaseContextOptionBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
            databaseContextOptionBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IWalletUserRepository, WalletUserRepository>();
        services.AddScoped<IWalletRepository, WalletRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IPointRepository, PointRepository>();

        return services;
    }
    
}