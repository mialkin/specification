using MediatR;
using Microsoft.EntityFrameworkCore;
using Specification.Infrastructure.Interfaces.Database;
using Specification.UseCases.Movies.Specifications;

namespace Specification.UseCases.Movies.Queries.Search;

public class SearchMoviesQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<SearchMoviesQuery, IReadOnlyCollection<SearchMoviesDto>>
{
    public async Task<IReadOnlyCollection<SearchMoviesDto>> Handle(
        SearchMoviesQuery request,
        CancellationToken cancellationToken)
    {
        var forKidsSpecification = new MovieForKidsSpecification();
        var onCdSpecification = new AvailableOnCdSpecification();

        // var specification = onCdSpecification.And(forKidsSpecification.Not());
        var movies = await readOnlyDatabaseContext.Movies
            .Where(forKidsSpecification.And(onCdSpecification).ToExpression())
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
