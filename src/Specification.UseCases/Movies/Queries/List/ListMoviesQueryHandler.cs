using MediatR;
using Microsoft.EntityFrameworkCore;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.UseCases.Movies.Queries.List;

internal class ListMoviesQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<ListMoviesQuery, IReadOnlyCollection<ListMoviesDto>>
{
    public async Task<IReadOnlyCollection<ListMoviesDto>> Handle(
        ListMoviesQuery request,
        CancellationToken cancellationToken)
    {
        var movies = await readOnlyDatabaseContext.Movies
            .Select(x => new ListMoviesDto(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        return movies;
    }
}
