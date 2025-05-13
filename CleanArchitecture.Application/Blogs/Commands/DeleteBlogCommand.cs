using MediatR;

namespace CleanArchitecture.Application.Blogs.Commands
{
    public record DeleteBlogCommand(int Id) : IRequest<bool>;
}
