using System.Linq.Expressions;
using Specification.Domain.Entities;

namespace Specification.UseCases.Movies.Specifications;

public sealed class AvailableOnCdSpecification : Specification<Movie>
{
    private const int MonthsBeforeDvdIsOut = 6;

    public override Expression<Func<Movie, bool>> ToExpression()
    {
        return x => x.ReleaseDate <= DateTime.UtcNow.AddYears(-7).AddMonths(-MonthsBeforeDvdIsOut);
    }
}
