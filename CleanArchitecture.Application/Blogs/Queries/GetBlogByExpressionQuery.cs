using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Queries
{
    public record GetBlogByExpressionQuery(Expression<Func<Blog, bool>> Expression) : IRequest<List<Blog>>;
}
