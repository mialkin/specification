using System.Linq.Expressions;
using Specification.Domain.Entities;

namespace Specification.UseCases.Movies.Specifications;

public sealed class AvailableOnCdSpecification(TimeProvider timeProvider) : Specification<Movie>
{
    private const int MonthsBeforeDvdIsOut = 6;

    public override Expression<Func<Movie, bool>> ToExpression()
    {
        return x => x.ReleaseDate <= timeProvider.GetUtcNow().AddMonths(-MonthsBeforeDvdIsOut);
    }
}
