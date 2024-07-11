using System.Linq.Expressions;

namespace Specification.UseCases;

internal sealed class AndSpecification<T>(Specification<T> leftSpecification, Specification<T> rightSpecification)
    : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = leftSpecification.ToExpression();
        var rightExpression = rightSpecification.ToExpression();

        var andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

        return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters.Single());
    }
}
