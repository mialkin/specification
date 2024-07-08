using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Specification.Domain;
using Specification.UseCases.Movies.Queries.Get;

namespace Specification.Api.Endpoints.Movies.Get;

public static class GetMovieEndpoint
{
    public static void MapGetMovie(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapGet(routePattern, async (
                Guid id,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetMovieQuery(id);
                var maybe = await sender.Send(query, cancellationToken);

                return maybe.HasValue
                    ? Results.Ok(maybe.Value.Adapt<GetMovieResponse>())
                    : Results.BadRequest(Errors.General.NotFound());
            })
            .Produces<GetMovieResponse>()
            .Produces<Error>(StatusCodes.Status400BadRequest)
            .WithOpenApi(operation => new OpenApiOperation(operation) { Summary = "Get movie" });
    }
}
