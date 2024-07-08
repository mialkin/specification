using MediatR;
using Microsoft.EntityFrameworkCore;
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
        var movies = await readOnlyDatabaseContext.Movies
            .Where(x => (x.MpaaRating <= MpaaRating.Pg || !request.ForKidsOnly)
                        && x.Rating >= request.MinimumRating
                        && (x.ReleaseDate <= DateTime.Now.AddMonths(-6) || !request.AvailableOnCd))
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
