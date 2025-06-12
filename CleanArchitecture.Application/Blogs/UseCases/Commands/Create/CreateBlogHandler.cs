using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Blogs.UseCases.Commands.Create
{
    public class CreateBlogHandler(IBlogRepository _blogRepository) : IRequestHandler<CreateBlogCommand, Blog>
    {
        public async Task<Blog> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog { Name = request.Name, Author = request.Author, Description = request.Description, ImageUrl = request.ImageUrl };
            await _blogRepository.CreateAsync(blog);
            return blog;
        }
    }
}
