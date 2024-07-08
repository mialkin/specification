using Specification.Domain.Entities;

namespace Specification.Infrastructure.Interfaces.Database;

public interface IReadOnlyDatabaseContext
{
    IQueryable<Movie> Movies { get; }
}
