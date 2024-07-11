using System.Linq.Expressions;

namespace Specification.UseCases;

internal sealed class OrSpecification<T>(Specification<T> leftSpecification, Specification<T> rightSpecification)
    : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = leftSpecification.ToExpression();
        var rightExpression = rightSpecification.ToExpression();

        var invokedExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);

        var lambdaExpression = Expression.Lambda(
            body: Expression.OrElse(leftExpression.Body, invokedExpression),
            parameters: leftExpression.Parameters);

        return (Expression<Func<T, bool>>)lambdaExpression;
    }
}
