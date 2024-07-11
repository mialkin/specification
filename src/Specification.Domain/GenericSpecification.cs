using System.Linq.Expressions;

namespace Specification.Domain;

public class GenericSpecification<T>
{
    public Expression<Func<T, bool>> Expression { get; set; }

    public GenericSpecification(Expression<Func<T, bool>> expression)
    {
        Expression = expression;
    }

    public bool IsSatisfiedBy(T entity)
    {
        return Expression.Compile().Invoke(entity);
    }
}
