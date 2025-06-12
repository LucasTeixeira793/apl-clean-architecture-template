using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Blogs.UseCases.Commands.Delete
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
