using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Blogs.Commands.Delete
{
    public class DeleteBlogHandler(IBlogRepository _blogRepository) : IRequestHandler<DeleteBlogCommand, Result>
    {
        public async Task<Result> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetSingleByExpressionAsync(d => d.Id == request.Id);
            if (blog is null)
                return ErrorsDomain.BlogNaoEncontrado;

            await _blogRepository.DeleteAsync(request.Id);
            return Result.Success();
        }
    }
}
