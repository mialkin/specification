using System.Linq.Expressions;
using Specification.Domain.Entities;

namespace Specification.Domain;

public sealed class MovieForKidsSpecification : Specification<Movie>
{
    public override Expression<Func<Movie, bool>> ToExpression()
    {
        return movie => movie.MpaaRating <= MpaaRating.Pg;
    }
}
