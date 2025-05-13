using CleanArchitecture.Application.Blogs.Commands;
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
    public class CreateBlogHandler(IBlogRepository _blogRepository) : IRequestHandler<CreateBlogCommand, int>
    {
        public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog { Name = request.Name, Author = request.Author, Description = request.Description, ImageUrl = request.ImageUrl };
            await _blogRepository.CreateAsync(blog);
            return blog.Id;
        }
    }
}
