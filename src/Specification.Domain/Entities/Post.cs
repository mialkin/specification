namespace Specification.Domain.Entities;

public class Post
{
    public Guid Id { get; set; }

    public Guid BlogId { get; set; }

    public required Blog Blog { get; set; }

    public required string Title { get; set; }

    public required string Text { get; set; }

    public bool Archived { get; set; }

    public DateTime CreatedAt { get; set; }
}
