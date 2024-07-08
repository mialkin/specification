using Microsoft.EntityFrameworkCore;
using Specification.Domain.Entities;

namespace Specification.Infrastructure.Interfaces.Database;

public interface IDatabaseContext
{
    public DbSet<Movie> Movies { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
