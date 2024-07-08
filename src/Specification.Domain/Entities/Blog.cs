namespace Specification.Domain.Entities;

public class Blog
{
    public Guid Id { get; }

    public Guid MovieId { get; set; }

    public required Movie Movie { get; set; }

    public required string Name { get; set; }

    public ICollection<Post> Posts { get; } = new List<Post>();
}
