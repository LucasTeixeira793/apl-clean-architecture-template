using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Blogs.UseCases.Queries.GetByExpression
{
    public class GetBlogByExpressionHandler(IBlogRepository _blogRepository) : IRequestHandler<GetBlogByExpressionQuery, List<Blog>>
    {
        public async Task<List<Blog>> Handle(GetBlogByExpressionQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetByExpressionAsync(request.Expression);
        }
    }
}
