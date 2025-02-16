namespace Specification.Api.Endpoints.Movies.Search;

public record SearchMoviesRequest(bool ForKidsOnly, double MinimumRating, bool AvailableOnCd, string? Director);
