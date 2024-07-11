using Specification.Domain.Entities;

namespace Specification.Infrastructure.Interfaces.Database;

public interface IReadOnlyDatabaseContext
{
    IQueryable<Director> Directors { get; }

    IQueryable<Movie> Movies { get; }
}
