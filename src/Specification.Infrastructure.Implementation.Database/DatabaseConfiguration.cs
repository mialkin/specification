using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.Infrastructure.Implementation.Database;

public static class DatabaseConfiguration
{
    public static IServiceCollection ConfigureDatabase(
        this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        ConfigureDatabaseContext(services, builderConfiguration);
        services.AddSingleton<IDatabaseErrorMessagesProvider, DatabaseErrorMessagesProvider>();

        return services;
    }

    private static void ConfigureDatabaseContext(IServiceCollection services, ConfigurationManager builderConfiguration)
    {
        var postgresSettings =
            builderConfiguration.GetRequiredSection(key: nameof(DatabaseSettings)).Get<DatabaseSettings>();

        if (string.IsNullOrWhiteSpace(postgresSettings?.ConnectionString))
        {
            throw new InvalidOperationException("Database connection string is not set");
        }

        services.AddDbContext<IDatabaseContext, DatabaseContext>(builder =>
        {
            builder
                .UseNpgsql(postgresSettings.ConnectionString)
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IReadOnlyDatabaseContext, ReadOnlyDatabaseContext>();
    }
}
