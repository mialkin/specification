using MediatR;

namespace Specification.UseCases.Movies.Queries.Search;

public record SearchMoviesQuery(bool ForKidsOnly, double MinimumRating, bool AvailableOnCd, string Director)
    : IRequest<IReadOnlyCollection<SearchMoviesDto>>;
