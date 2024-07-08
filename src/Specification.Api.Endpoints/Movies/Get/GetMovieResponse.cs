using Specification.Domain.Entities;

namespace Specification.Api.Endpoints.Movies.Get;

public record GetMovieResponse(
    Guid Id,
    string Name,
    DateTime ReleaseDate,
    MpaaRating MpaaRating,
    string Genre,
    double Rating);
