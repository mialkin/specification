using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Time.Testing;
using Specification.Domain.Entities;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.UseCases.Movies.Queries.Search;

public class SearchMoviesQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<SearchMoviesQuery, IReadOnlyCollection<SearchMoviesDto>>
{
    public async Task<IReadOnlyCollection<SearchMoviesDto>> Handle(
        SearchMoviesQuery request,
        CancellationToken cancellationToken)
    {
        var fakeTimeProvider = new FakeTimeProvider(new DateTimeOffset(new DateTime(2017, 1, 1)));

        // A movie is available on CD if it has been released at least 6 months ago.
        var halfYearAgo = fakeTimeProvider.GetUtcNow().AddMonths(-6).UtcDateTime;

        var movies = await readOnlyDatabaseContext.Movies
            .Where(x => (x.MpaaRating <= MpaaRating.Pg || !request.ForKidsOnly)
                        && x.Rating >= request.MinimumRating
                        && (x.ReleaseDate <= halfYearAgo || !request.AvailableOnCd))
            .Select(x => new SearchMoviesDto(
                x.Id,
                x.Name,
                x.ReleaseDate,
                x.MpaaRating,
                x.Genre,
                x.Rating))
            .ToListAsync(cancellationToken);

        return movies;
    }
}
