using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Blogs.UseCases.Queries.GetAll
{
    public record GetAllBlogsQuery : IRequest<List<Blog>>;
}
