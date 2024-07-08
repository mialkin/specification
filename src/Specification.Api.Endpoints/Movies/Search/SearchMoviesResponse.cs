using Specification.UseCases.Movies.Queries.Search;

namespace Specification.Api.Endpoints.Movies.Search;

public record SearchMoviesResponse(IReadOnlyCollection<SearchMoviesDto> Movies);
