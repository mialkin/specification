namespace Specification.Domain.Entities;

public class Movie
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required DateTime ReleaseDate { get; set; }

    public required MpaaRating MpaaRating { get; set; }

    public required string Genre { get; set; }

    public required double Rating { get; set; }
}
