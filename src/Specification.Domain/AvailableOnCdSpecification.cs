using System.Linq.Expressions;
using Specification.Domain.Entities;

namespace Specification.Domain;

public sealed class AvailableOnCdSpecification(TimeProvider timeProvider) : Specification<Movie>
{
    private const int MonthsBeforeDvdIsOut = 6;

    public override Expression<Func<Movie, bool>> ToExpression()
    {
        return movie => movie.ReleaseDate <= timeProvider.GetUtcNow().AddMonths(-MonthsBeforeDvdIsOut);
    }
}
