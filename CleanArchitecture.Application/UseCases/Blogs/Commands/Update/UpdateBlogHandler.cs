using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Blogs.Commands.Update
{
    public class UpdateBlogHandler(IBlogRepository _blogRepository) : IRequestHandler<UpdateBlogCommand, Result<Blog>>
    {
        public async Task<Result<Blog>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetSingleByExpressionAsync(a => a.Id == request.Id);
            if (blog is null)
                return ErrorsDomain.BlogNaoEncontrado;

            blog.Name = request.Name ?? blog.Name;
            blog.Description = request.Description ?? blog.Description;
            blog.Author = request.Author ?? blog.Author;
            blog.ImageUrl = request.ImageUrl ?? blog.ImageUrl;

            await _blogRepository.UpdateAsync(blog, request.Id);
            return blog;
        }
    }
}
