using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Specification.UseCases.Movies.Commands.Create;

namespace Specification.Api.Endpoints.Movies.Create;

public static class CreateMovieEndpoint
{
    public static void MapCreateMovie(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, async (
                [FromBody] CreateMovieRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<CreateMovieCommand>();
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value.Adapt<CreateMovieResponse>())
                    : Results.BadRequest(result.Error);
            })
            .Produces<CreateMovieResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Create movie" });
    }
}
