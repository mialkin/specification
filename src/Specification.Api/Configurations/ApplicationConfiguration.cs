using Specification.Infrastructure.Implementation.Database;

namespace Specification.Api.Configurations;

public static class ApplicationConfiguration
{
    public static void ConfigureApplication(
        this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services.ConfigureMediatr();
        services.ConfigureDatabase(builderConfiguration);
    }
}
