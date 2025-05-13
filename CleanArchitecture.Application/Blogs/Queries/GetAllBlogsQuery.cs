using CleanArchitecture.Application.Blogs.Dto;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Queries
{
    public record GetAllBlogsQuery : IRequest<List<Blog>>;
}
