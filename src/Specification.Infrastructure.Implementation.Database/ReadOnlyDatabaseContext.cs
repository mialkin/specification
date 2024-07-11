using Microsoft.EntityFrameworkCore;
using Specification.Domain.Entities;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.Infrastructure.Implementation.Database;

internal sealed class ReadOnlyDatabaseContext(IDatabaseContext databaseContext) : IReadOnlyDatabaseContext
{
    public IQueryable<Director> Directors => databaseContext.Directors.AsNoTracking();

    public IQueryable<Movie> Movies => databaseContext.Movies.AsNoTracking();
}
