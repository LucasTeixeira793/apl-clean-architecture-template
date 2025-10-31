using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.UseCases.Blogs.Queries.GetByExpression
{
    public record GetSingleBlogByExpressionQuery(Expression<Func<Blog, bool>> Expression) : IRequest<Result<Blog>>;
}
