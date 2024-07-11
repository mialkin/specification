using MediatR;
using Microsoft.EntityFrameworkCore;
using Specification.Domain.Entities;
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
        var specification = Specification<Movie>.All;

        if (request.ForKidsOnly)
        {
            specification = specification.And(new MovieForKidsSpecification());
        }

        if (request.AvailableOnCd)
        {
            specification = specification.And(new AvailableOnCdSpecification());
        }

        var movies = await readOnlyDatabaseContext.Movies
            .Where(specification.ToExpression())
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
