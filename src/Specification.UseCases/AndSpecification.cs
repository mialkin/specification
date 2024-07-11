using System.Linq.Expressions;

namespace Specification.UseCases;

internal sealed class AndSpecification<T>(Specification<T> leftSpecification, Specification<T> rightSpecification)
    : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = leftSpecification.ToExpression();
        var rightExpression = rightSpecification.ToExpression();

        var invocationExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);

        var lambdaExpression = Expression.Lambda(
            body: Expression.AndAlso(leftExpression.Body, invocationExpression),
            parameters: leftExpression.Parameters);

        return (Expression<Func<T, bool>>)lambdaExpression;
    }
}
