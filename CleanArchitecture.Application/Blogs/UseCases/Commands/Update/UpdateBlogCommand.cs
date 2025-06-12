using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Blogs.UseCases.Commands.Update;

public record UpdateBlogCommand(int Id, string Name, string Description, string Author, string ImageUrl) : IRequest<Result<Blog>>;

public record UpdateBlogDto(string Name, string Description, string Author, string ImageUrl);