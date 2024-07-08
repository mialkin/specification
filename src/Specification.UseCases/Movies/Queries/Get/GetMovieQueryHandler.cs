using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.UseCases.Movies.Queries.Get;

internal class GetMovieQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<GetMovieQuery, Maybe<GetMovieDto>>
{
    public async Task<Maybe<GetMovieDto>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        var movie = await readOnlyDatabaseContext.Movies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return movie is null ? Maybe.None : Maybe.From(movie.Adapt<GetMovieDto>());
    }
}
