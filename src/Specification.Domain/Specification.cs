using System.Linq.Expressions;

namespace Specification.Domain;

public abstract class Specification<T>
{
    public bool IsSatisfiedBy(T entity)
    {
        var predicate = ToExpression().Compile();
        return predicate(entity);
    }

    public abstract Expression<Func<T, bool>> ToExpression();
}
