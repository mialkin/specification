using Specification.Domain.Entities;
using Specification.UseCases.Directors;

namespace Specification.UseCases.Movies.Queries.Search;

public record SearchMoviesDto(
    Guid Id,
    string Name,
    DateTime ReleaseDate,
    MpaaRating MpaaRating,
    string Genre,
    double Rating,
    ListDirectorDto Director);
