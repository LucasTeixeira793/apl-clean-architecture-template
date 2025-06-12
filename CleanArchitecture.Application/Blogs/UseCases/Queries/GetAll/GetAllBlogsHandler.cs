using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Blogs.UseCases.Queries.GetAll
{
    public class GetAllBlogsHandler(IBlogRepository _blogRepository) : IRequestHandler<GetAllBlogsQuery, List<Blog>>
    {
        public async Task<List<Blog>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetAllAsync();

        }
    }
}
