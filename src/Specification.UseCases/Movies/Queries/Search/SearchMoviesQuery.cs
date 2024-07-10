using System.Linq.Expressions;
using MediatR;
using Specification.Domain.Entities;

namespace Specification.UseCases.Movies.Queries.Search;

public record SearchMoviesQuery(Expression<Func<Movie, bool>> Expression)
    : IRequest<IReadOnlyCollection<SearchMoviesDto>>;
