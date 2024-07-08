using CSharpFunctionalExtensions;
using MediatR;
using Specification.Domain;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.UseCases.Movies.Commands.Update;

internal class UpdateMovieCommandHandler(
    IDatabaseContext databaseContext,
    IDatabaseErrorMessagesProvider databaseErrorMessagesProvider)
    : IRequestHandler<UpdateMovieCommand, UnitResult<Error>>
{
    public async Task<UnitResult<Error>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await databaseContext.Movies.FindAsync(request.Id, cancellationToken);
        if (movie is null)
        {
            return UnitResult.Failure(Errors.General.NotFound());
        }

        movie.Name = request.Name;

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

        return UnitResult.Success<Error>();
    }
}
