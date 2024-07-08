using Specification.UseCases.Movies.Commands.Create;

namespace Specification.Api.Configurations;

public static class MediatrConfiguration
{
    public static void ConfigureMediatr(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<CreateMovieCommand>());
    }
}
