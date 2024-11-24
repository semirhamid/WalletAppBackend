using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace WalletApp.Infrastructure.Persistence.Options;

public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{
    public const string ConfigurationSectionName = "DatabaseOptions";
    private readonly IConfiguration _configuration;

    public DatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void Configure(DatabaseOptions options)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        options.ConnectionString = connectionString;
        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}