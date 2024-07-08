using CSharpFunctionalExtensions;
using MediatR;
using Specification.Domain;
using Specification.Domain.Entities;

namespace Specification.UseCases.Movies.Commands.Create;

public record CreateMovieCommand(
    string Name,
    DateTime ReleaseDate,
    MpaaRating MpaaRating,
    string Genre,
    double Rating)
    : IRequest<Result<CreateMovieDto, Error>>;
