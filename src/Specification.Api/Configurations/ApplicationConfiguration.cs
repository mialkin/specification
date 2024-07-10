using Microsoft.Extensions.Time.Testing;
using Specification.Infrastructure.Implementation.Database;

namespace Specification.Api.Configurations;

public static class ApplicationConfiguration
{
    public static void ConfigureApplication(
        this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services.AddSingleton<TimeProvider>(new FakeTimeProvider(new DateTimeOffset(new DateTime(2017, 1, 1))));
        services.ConfigureMediatr();
        services.ConfigureDatabase(builderConfiguration);
    }
}
