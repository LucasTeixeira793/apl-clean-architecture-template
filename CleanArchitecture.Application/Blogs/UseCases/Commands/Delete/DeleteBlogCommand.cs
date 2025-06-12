using MediatR;

namespace CleanArchitecture.Application.Blogs.UseCases.Commands.Delete
{
    public record DeleteBlogCommand(int Id) : IRequest<bool>;
}
