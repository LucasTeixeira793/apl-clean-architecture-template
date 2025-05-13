using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Commands
{
    public record CreateBlogCommand(string Name, string Description, string Author, string ImageUrl) : IRequest<int>
    {
    }
}
