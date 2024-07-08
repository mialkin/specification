using MediatR;

namespace Specification.UseCases.Movies.Queries.Search;

public record SearchMoviesQuery(string Term) : IRequest<IReadOnlyCollection<SearchMoviesDto>>;
