using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Specification.UseCases.Movies.Commands.Update;

namespace Specification.Api.Endpoints.Movies.Update;

public static class UpdateMovieEndpoint
{
    public static void MapUpdateMovie(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPatch(routePattern, async (
                [FromBody] UpdateMovieRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<UpdateMovieCommand>();
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok()
                    : Results.BadRequest(result.Error);
            })
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Update movie" });
    }
}
