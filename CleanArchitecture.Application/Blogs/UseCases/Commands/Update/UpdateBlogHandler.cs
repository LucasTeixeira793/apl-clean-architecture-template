using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Blogs.UseCases.Commands.Update
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
