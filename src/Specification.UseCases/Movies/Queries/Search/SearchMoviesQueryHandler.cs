using MediatR;
using Microsoft.EntityFrameworkCore;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.UseCases.Movies.Queries.Search;

public class SearchMoviesQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext, TimeProvider timeProvider)
    : IRequestHandler<SearchMoviesQuery, IReadOnlyCollection<SearchMoviesDto>>
{
    public async Task<IReadOnlyCollection<SearchMoviesDto>> Handle(
        SearchMoviesQuery request,
        CancellationToken cancellationToken)
    {
        // A movie is available on CD if it has been released at least 6 months ago.
        var halfYearAgo = timeProvider.GetUtcNow().AddMonths(-6).UtcDateTime;

        var movies = await readOnlyDatabaseContext.Movies
            .Where(request.Expression)
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
