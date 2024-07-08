using Specification.UseCases.Movies.Queries.List;

namespace Specification.Api.Endpoints.Movies.List;

public record ListMoviesResponse(IReadOnlyCollection<ListMoviesDto> Movies);
