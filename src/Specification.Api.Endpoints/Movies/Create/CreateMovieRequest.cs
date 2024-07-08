using Specification.Domain.Entities;

namespace Specification.Api.Endpoints.Movies.Create;

public record CreateMovieRequest(
    string Name,
    DateTime ReleaseDate,
    MpaaRating MpaaRating,
    string Genre,
    double Rating);
