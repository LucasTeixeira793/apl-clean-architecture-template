using CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Blogs.Commands.Delete
{
    public record DeleteBlogCommand(int Id) : IRequest<Result>;
}
