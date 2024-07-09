using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using Specification.Domain;
using Specification.UseCases.Tickets.Commands.BuyOnCd;

namespace Specification.Api.Endpoints.Tickets.BuyOnCd;

public static class BuyOnCdTicketEndpoint
{
    public static void MapBuyOnCdTicket(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, async (
                [FromBody] BuyOnCdTicketRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<BuyOnCdTicketCommand>();
                var result = await sender.Send(command, cancellationToken);

                if (result.IsFailure)
                {
                    return Results.BadRequest(result.Error);
                }

                var maybeResult = result.Value;

                return maybeResult.HasValue
                    ? Results.Ok(maybeResult.Value.Adapt<BuyOnCdTicketResponse>())
                    : Results.BadRequest(Errors.General.NotFound());
            })
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Buy on CD ticket" });
    }
}
