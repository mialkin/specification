namespace Specification.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }

    public required string Text { get; set; }

    public Guid MovieId { get; set; }

    public required Movie Movie { get; set; }

    public Guid PostId { get; set; }

    public required Post Post { get; set; }
}
