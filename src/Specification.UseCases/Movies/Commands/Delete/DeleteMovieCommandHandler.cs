using MediatR;
using Microsoft.EntityFrameworkCore;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.UseCases.Movies.Commands.Delete;

internal class DeleteMovieCommandHandler(IDatabaseContext databaseContext)
    : IRequestHandler<DeleteMovieCommand>
{
    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        await databaseContext.Movies.Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }
}
