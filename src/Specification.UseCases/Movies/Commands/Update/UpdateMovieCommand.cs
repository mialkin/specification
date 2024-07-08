using CSharpFunctionalExtensions;
using MediatR;
using Specification.Domain;

namespace Specification.UseCases.Movies.Commands.Update;

public record UpdateMovieCommand(Guid Id, string Name) : IRequest<UnitResult<Error>>;
