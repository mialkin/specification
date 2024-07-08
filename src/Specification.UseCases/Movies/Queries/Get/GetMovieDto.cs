using Specification.Domain.Entities;

namespace Specification.UseCases.Movies.Queries.Get;

public record GetMovieDto(
    Guid Id,
    string Name,
    DateTime ReleaseDate,
    MpaaRating MpaaRating,
    string Genre,
    double Rating);
