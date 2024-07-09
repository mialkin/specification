using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.UseCases.Tickets.Commands.BuyAdult;

internal class BuyAdultTicketCommandHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<BuyAdultTicketCommand, Maybe<BuyAdultTicketDto>>
{
    public async Task<Maybe<BuyAdultTicketDto>> Handle(
        BuyAdultTicketCommand request,
        CancellationToken cancellationToken)
    {
        var movie = await readOnlyDatabaseContext.Movies
            .FirstOrDefaultAsync(x => x.Id == request.MovieId, cancellationToken);

        return movie is null
            ? Maybe<BuyAdultTicketDto>.None
            : Maybe.From(new BuyAdultTicketDto("You've bought a ticket"));
    }
}
