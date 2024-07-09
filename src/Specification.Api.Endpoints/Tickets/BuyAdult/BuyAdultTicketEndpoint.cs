using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Specification.Domain;
using Specification.UseCases.Tickets.Commands.BuyAdult;

namespace Specification.Api.Endpoints.Tickets.BuyAdult;

public static class BuyAdultTicketEndpoint
{
    public static void MapBuyAdultTicket(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, async (
                [FromBody] BuyAdultTicketRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<BuyAdultTicketCommand>();
                var result = await sender.Send(command, cancellationToken);

                return result.HasValue
                    ? Results.Ok(result.Value.Adapt<BuyAdultTicketResponse>())
                    : Results.BadRequest(Errors.General.NotFound());
            })
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Buy adult ticket" });
    }
}
