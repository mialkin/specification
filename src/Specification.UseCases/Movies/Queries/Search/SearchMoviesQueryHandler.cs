using MediatR;
using Microsoft.EntityFrameworkCore;
using Specification.Domain.Entities;
using Specification.Infrastructure.Interfaces.Database;
using Specification.UseCases.Directors;
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
            specification &= new MovieForKidsSpecification();
        }

        if (request.AvailableOnCd)
        {
            specification &= new AvailableOnCdSpecification();
        }

        if (!string.IsNullOrWhiteSpace(request.Director))
        {
            specification &= new MovieDirectedBySpecification(request.Director);
        }

        var movies = await readOnlyDatabaseContext.Movies
            .Where(specification.ToExpression())
            .Where(x => x.Rating >= request.MinimumRating)
            .Select(x => new SearchMoviesDto(
                x.Id,
                x.Name,
                x.ReleaseDate,
                x.MpaaRating,
                x.Genre,
                x.Rating,
                new ListDirectorDto(x.DirectorId, x.Director!.Name)))
            .ToListAsync(cancellationToken);

        return movies;
    }
}
