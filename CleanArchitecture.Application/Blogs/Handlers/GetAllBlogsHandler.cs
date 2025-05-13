using CleanArchitecture.Application.Blogs.Dto;
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
    public class GetAllBlogsHandler(IBlogRepository _blogRepository) : IRequestHandler<GetAllBlogsQuery, List<Blog>>
    {
        public async Task<List<Blog>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetAllAsync();

        }
    }
}
