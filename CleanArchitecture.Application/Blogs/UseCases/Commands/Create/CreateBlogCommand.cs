using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Blogs.UseCases.Commands.Create
{
    public record CreateBlogCommand(string Name, string Description, string Author, string ImageUrl) : IRequest<Blog>
    {
    }
}
