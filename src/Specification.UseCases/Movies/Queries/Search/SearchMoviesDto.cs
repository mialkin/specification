using Specification.Domain.Entities;

namespace Specification.UseCases.Movies.Queries.Search;

public record SearchMoviesDto(
    Guid Id,
    string Name,
    DateTime ReleaseDate,
    MpaaRating MpaaRating,
    string Genre,
    double Rating);
