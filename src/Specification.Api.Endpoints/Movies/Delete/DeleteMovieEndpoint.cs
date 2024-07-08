using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Specification.UseCases.Movies.Commands.Delete;

namespace Specification.Api.Endpoints.Movies.Delete;

public static class DeleteMovieEndpoint
{
    public static void MapDeleteMovie(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapDelete(routePattern, async (
                [FromBody] DeleteMovieRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = new DeleteMovieCommand(request.Id);
                await sender.Send(command, cancellationToken);

                return Results.Ok();
            })
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Delete movie" });
    }
}
