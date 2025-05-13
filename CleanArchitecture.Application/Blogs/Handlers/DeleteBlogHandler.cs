using CleanArchitecture.Application.Blogs.Commands;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Handlers
{
    public class DeleteBlogHandler(IBlogRepository _blogRepository) : IRequestHandler<DeleteBlogCommand, bool>
    {
        public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = (await _blogRepository.GetByExpressionAsync(d => d.Id == request.Id)).FirstOrDefault();
            if (blog is null)
                return false;
            await _blogRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
