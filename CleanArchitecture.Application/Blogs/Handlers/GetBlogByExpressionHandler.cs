using CleanArchitecture.Application.Blogs.Queries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Handlers
{
    public class GetBlogByExpressionHandler(IBlogRepository _blogRepository) : IRequestHandler<GetBlogByExpressionQuery, List<Blog>>
    {
        public async Task<List<Blog>> Handle(GetBlogByExpressionQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetByExpressionAsync(request.Expression);
        }
    }
}
