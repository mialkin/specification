using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Specification.Domain;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.UseCases.Tickets.Commands.BuyOnCd;

internal class BuyOnCdTicketCommandHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext, TimeProvider timeProvider)
    : IRequestHandler<BuyOnCdTicketCommand, Result<Maybe<BuyOnCdTicketDto>, Error>>
{
    public async Task<Result<Maybe<BuyOnCdTicketDto>, Error>> Handle(
        BuyOnCdTicketCommand request,
        CancellationToken cancellationToken)
    {
        var movie = await readOnlyDatabaseContext.Movies
            .FirstOrDefaultAsync(x => x.Id == request.MovieId, cancellationToken);

        if (movie is null)
        {
            return Maybe<BuyOnCdTicketDto>.None;
        }

        var specification = new AvailableOnCdSpecification(timeProvider);
        if (!specification.IsSatisfiedBy(movie))
        {
            return Errors.Movie.DoesNotHaveCdVersion();
        }

        return Maybe.From(new BuyOnCdTicketDto("You've bought a ticket"));
    }
}
