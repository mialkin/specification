using Specification.Domain.Entities;

namespace Specification.UseCases.Movies.Queries.List;

public record ListMoviesDto(
    Guid Id,
    string Name,
    DateTime ReleaseDate,
    MpaaRating MpaaRating,
    string Genre,
    double Rating);
