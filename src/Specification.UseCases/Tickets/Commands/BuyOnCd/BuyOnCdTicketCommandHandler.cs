using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Specification.Domain;
using Specification.Domain.Entities;
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

        var hasCdVersion = Movie.HasCdVersion.Compile();
        if (!hasCdVersion(movie))
        {
            return Errors.Movie.DoesNotHaveCdVersion();
        }

        return Maybe.From(new BuyOnCdTicketDto("You've bought a ticket"));
    }
}
