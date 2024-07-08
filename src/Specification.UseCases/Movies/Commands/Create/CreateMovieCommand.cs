using CSharpFunctionalExtensions;
using MediatR;
using Specification.Domain;

namespace Specification.UseCases.Movies.Commands.Create;

public record CreateMovieCommand(string Name) : IRequest<Result<CreateMovieDto, Error>>;
