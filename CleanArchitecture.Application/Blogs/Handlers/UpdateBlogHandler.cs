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
    public class UpdateBlogHandler(IBlogRepository _blogRepository) : IRequestHandler<UpdateBlogCommand, bool>
    {
        public async Task<bool> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = (await _blogRepository.GetByExpressionAsync(a => a.Id == request.Id)).FirstOrDefault();
            if (blog is null)
                return false;

            blog.Name = request.Name ?? blog.Name;
            blog.Description = request.Description ?? blog.Description;
            blog.Author = request.Author ?? blog.Author;
            blog.ImageUrl = request.ImageUrl ?? blog.ImageUrl;

            await _blogRepository.UpdateAsync(blog, request.Id);
            return true;
        }
    }
}
