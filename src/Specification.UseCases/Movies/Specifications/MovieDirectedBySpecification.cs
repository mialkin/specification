using System.Linq.Expressions;
using Specification.Domain.Entities;

namespace Specification.UseCases.Movies.Specifications;

public sealed class MovieDirectedBySpecification(string director) : Specification<Movie>
{
    public override Expression<Func<Movie, bool>> ToExpression()
    {
        return x => x.Director!.Name == director;
    }
}
