namespace Specification.Domain.Entities;

public class Movie
{
    public Guid Id { get; set; }

    public required string Name { get; set; }
}
