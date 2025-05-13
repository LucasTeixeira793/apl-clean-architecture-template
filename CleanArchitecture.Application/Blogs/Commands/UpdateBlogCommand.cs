using MediatR;

namespace CleanArchitecture.Application.Blogs.Commands;

public record UpdateBlogCommand(int Id, string Name, string Description, string Author, string ImageUrl) : IRequest<bool>;

public record UpdateBlogDto(string Name, string Description, string Author, string ImageUrl);