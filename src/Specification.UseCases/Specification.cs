using System.Linq.Expressions;

namespace Specification.UseCases;

public abstract class Specification<T>
{
    public static readonly Specification<T> All = new IdentitySpecification<T>();

    public bool IsSatisfiedBy(T entity)
    {
        var predicate = ToExpression().Compile();
        return predicate(entity);
    }

    public abstract Expression<Func<T, bool>> ToExpression();

    private Specification<T> And(Specification<T> specification)
    {
        if (this == All)
        {
            return specification;
        }

        if (specification == All)
        {
            return this;
        }

        return new AndSpecification<T>(this, specification);
    }

    private Specification<T> Or(Specification<T> specification)
    {
        if (this == All || specification == All)
        {
            return All;
        }

        return new OrSpecification<T>(this, specification);
    }

    private Specification<T> Not() => new NotSpecification<T>(this);

    public static Specification<T> operator &(Specification<T> left, Specification<T> right) => left.And(right);

    public static Specification<T> operator |(Specification<T> left, Specification<T> right) => left.Or(right);

    public static Specification<T> operator !(Specification<T> specification) => specification.Not();
}
