using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Blogs.Queries.GetAll
{
    public record GetAllBlogsQuery : IRequest<Result<List<Blog>>>;
}
