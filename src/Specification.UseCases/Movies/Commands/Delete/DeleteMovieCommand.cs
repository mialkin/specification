using MediatR;

namespace Specification.UseCases.Movies.Commands.Delete;

public record DeleteMovieCommand(Guid Id) : IRequest;
