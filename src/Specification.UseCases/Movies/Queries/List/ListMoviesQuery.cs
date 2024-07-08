using MediatR;

namespace Specification.UseCases.Movies.Queries.List;

public record ListMoviesQuery : IRequest<IReadOnlyCollection<ListMoviesDto>>;
