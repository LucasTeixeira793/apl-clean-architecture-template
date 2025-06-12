using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Blogs.UseCases.Queries.GetAll
{
    public class GetAllBlogsHandler(IBlogRepository _blogRepository) : IRequestHandler<GetAllBlogsQuery, Result<List<Blog>>>
    {
        public async Task<Result<List<Blog>>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetAllAsync();
        }
    }
}
