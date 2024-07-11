using MediatR;

namespace Specification.UseCases.Movies.Queries.Search;

public record SearchMoviesQuery(bool ForKidsOnly, double MinimumRating, bool AvailableOnCd)
    : IRequest<IReadOnlyCollection<SearchMoviesDto>>;
