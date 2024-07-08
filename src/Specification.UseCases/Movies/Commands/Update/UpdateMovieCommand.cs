using CSharpFunctionalExtensions;
using MediatR;
using Specification.Domain;
using Specification.Domain.Entities;

namespace Specification.UseCases.Movies.Commands.Update;

public record UpdateMovieCommand(
    Guid Id,
    string Name,
    DateTime ReleaseDate,
    MpaaRating MpaaRating,
    string Genre,
    double Rating) : IRequest<UnitResult<Error>>;
