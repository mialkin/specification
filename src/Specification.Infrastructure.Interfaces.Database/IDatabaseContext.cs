using Microsoft.EntityFrameworkCore;
using Specification.Domain.Entities;

namespace Specification.Infrastructure.Interfaces.Database;

public interface IDatabaseContext
{
    public DbSet<Movie> Movies { get; }

    public DbSet<Blog> Blogs { get; }

    public DbSet<Post> Posts { get; }

    public DbSet<Comment> Comments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
