using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Specification.UseCases.Movies.Queries.Search;

namespace Specification.Api.Endpoints.Movies.Search;

public static class SearchMoviesEndpoint
{
    public static void MapSearchMovies(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                [AsParameters] SearchMoviesRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new SearchMoviesQuery(request.Term);
                var movies = await sender.Send(query, cancellationToken);

                return Results.Ok(new SearchMoviesResponse(movies));
            })
            .Produces<SearchMoviesResponse>()
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Search movies" });
    }
}
