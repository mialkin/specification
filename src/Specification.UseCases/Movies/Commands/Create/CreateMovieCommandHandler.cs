using CSharpFunctionalExtensions;
using MediatR;
using Specification.Domain;
using Specification.Domain.Entities;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.UseCases.Movies.Commands.Create;

internal class CreateMovieCommandHandler(
    IDatabaseContext databaseContext,
    IDatabaseErrorMessagesProvider databaseErrorMessagesProvider)
    : IRequestHandler<CreateMovieCommand, Result<CreateMovieDto, Error>>
{
    public async Task<Result<CreateMovieDto, Error>> Handle(
        CreateMovieCommand request,
        CancellationToken cancellationToken)
    {
        var movie = new Movie { Id = Guid.NewGuid(), Name = request.Name };

        databaseContext.Movies.Add(movie);

        try
        {
            await databaseContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            if (exception.InnerException != null &&
                exception.InnerException.Message.Contains(databaseErrorMessagesProvider.MovieNameUniquenessViolation))
            {
                return Errors.Word.NameAlreadyExists();
            }

            throw;
        }

        return new CreateMovieDto(movie.Id);
    }
}
