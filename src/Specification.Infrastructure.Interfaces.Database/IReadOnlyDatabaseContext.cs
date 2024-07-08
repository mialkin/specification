using Specification.Domain.Entities;

namespace Specification.Infrastructure.Interfaces.Database;

public interface IReadOnlyDatabaseContext
{
    IQueryable<Movie> Movies { get; }

    IQueryable<Blog> Blogs { get; }

    IQueryable<Post> Posts { get; }

    IQueryable<Comment> Comments { get; }
}
