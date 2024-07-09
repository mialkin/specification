using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Specification.Domain;
using Specification.Domain.Entities;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.UseCases.Tickets.Commands.BuyChild;

internal class BuyChildTicketCommandHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<BuyChildTicketCommand, Result<Maybe<BuyChildTicketDto>, Error>>
{
    public async Task<Result<Maybe<BuyChildTicketDto>, Error>> Handle(
        BuyChildTicketCommand request,
        CancellationToken cancellationToken)
    {
        var movie = await readOnlyDatabaseContext.Movies
            .FirstOrDefaultAsync(x => x.Id == request.MovieId, cancellationToken);

        if (movie is null)
        {
            return Maybe<BuyChildTicketDto>.None;
        }

        if (movie.MpaaRating > MpaaRating.Pg)
        {
            return Errors.Movie.NotSuitableForChildren();
        }

        return Maybe.From(new BuyChildTicketDto("You've bought a ticket"));
    }
}
