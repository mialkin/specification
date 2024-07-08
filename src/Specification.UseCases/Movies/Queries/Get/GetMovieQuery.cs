using CSharpFunctionalExtensions;
using MediatR;

namespace Specification.UseCases.Movies.Queries.Get;

public record GetMovieQuery(Guid Id) : IRequest<Maybe<GetMovieDto>>;
