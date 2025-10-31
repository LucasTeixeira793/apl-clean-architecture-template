using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Blogs.Queries.GetByExpression
{
    public class GetSingleBlogByExpressionHandler(IBlogRepository _blogRepository) : IRequestHandler<GetSingleBlogByExpressionQuery, Result<Blog>>
    {
        public async Task<Result<Blog>> Handle(GetSingleBlogByExpressionQuery request, CancellationToken cancellationToken)
        {
            var data = await _blogRepository.GetSingleByExpressionAsync(request.Expression);
            if (data is null)
                return ErrorsDomain.BlogNaoEncontrado;
            return data;
        }
    }
}
