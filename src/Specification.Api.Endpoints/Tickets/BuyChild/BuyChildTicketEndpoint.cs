using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Specification.Domain;
using Specification.UseCases.Tickets.Commands.BuyChild;

namespace Specification.Api.Endpoints.Tickets.BuyChild;

public static class BuyChildTicketEndpoint
{
    public static void MapBuyChildTicket(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, async (
                [FromBody] BuyChildTicketRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<BuyChildTicketCommand>();
                var result = await sender.Send(command, cancellationToken);

                if (result.IsFailure)
                {
                    return Results.BadRequest(result.Error);
                }

                var maybeResult = result.Value;

                return maybeResult.HasValue
                    ? Results.Ok(maybeResult.Value.Adapt<BuyChildTicketResponse>())
                    : Results.BadRequest(Errors.General.NotFound());
            })
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Buy child ticket" });
    }
}
