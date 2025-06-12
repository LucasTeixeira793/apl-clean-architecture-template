using CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Application.Blogs.UseCases.Commands.Delete
{
    public record DeleteBlogCommand(int Id) : IRequest<Result>;
}
