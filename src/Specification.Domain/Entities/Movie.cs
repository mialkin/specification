using System.Linq.Expressions;
using Microsoft.Extensions.Time.Testing;

namespace Specification.Domain.Entities;

public class Movie
{
    static Movie()
    {
        _sTimeProvider = new FakeTimeProvider(new DateTimeOffset(new DateTime(2017, 1, 1)));
    }

    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required DateTime ReleaseDate { get; set; }

    public required MpaaRating MpaaRating { get; set; }

    public required string Genre { get; set; }

    public required double Rating { get; set; }

    public static readonly Expression<Func<Movie, bool>> IsSuitableForChildren = x => x.MpaaRating <= MpaaRating.Pg;

    public static readonly Expression<Func<Movie, bool>> HasCdVersion =
        x => x.ReleaseDate <= _sTimeProvider!.GetUtcNow().AddMonths(-6);

    private static readonly TimeProvider _sTimeProvider;
}
