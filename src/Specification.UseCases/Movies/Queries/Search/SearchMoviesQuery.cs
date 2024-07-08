using MediatR;

namespace Specification.UseCases.Movies.Queries.Search;

public record SearchMoviesQuery(bool ForKidsOnly) : IRequest<IReadOnlyCollection<SearchMoviesDto>>;
