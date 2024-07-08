using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Specification.UseCases.Movies.Queries.List;

namespace Specification.Api.Endpoints.Movies.List;

public static class ListMoviesEndpoint
{
    public static void MapListMovies(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new ListMoviesQuery();
                var movies = await sender.Send(query, cancellationToken);

                return Results.Ok(new ListMoviesResponse(movies));
            })
            .Produces<ListMoviesResponse>()
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "List movies" });
    }
}
