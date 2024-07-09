using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Time.Testing;
using Specification.Domain;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.UseCases.Tickets.Commands.BuyOnCd;

internal class BuyOnCdTicketCommandHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
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

        var fakeTimeProvider = new FakeTimeProvider(new DateTimeOffset(new DateTime(2017, 1, 1)));

        // A movie is available on CD if it has been released at least 6 months ago.
        var halfYearAgo = fakeTimeProvider.GetUtcNow().AddMonths(-6).UtcDateTime;
        if (movie.ReleaseDate >= halfYearAgo)
        {
            return Errors.Movie.DoesNotHaveCdVersion();
        }

        return Maybe.From(new BuyOnCdTicketDto("You've bought a ticket"));
    }
}
