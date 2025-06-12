using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Blogs.UseCases.Queries.GetByExpression
{
    public record GetBlogByExpressionQuery(Expression<Func<Blog, bool>> Expression) : IRequest<List<Blog>>;
}
