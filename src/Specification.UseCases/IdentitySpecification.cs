using System.Linq.Expressions;

namespace Specification.UseCases;

internal sealed class IdentitySpecification<T> : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression() => x => true;
}
