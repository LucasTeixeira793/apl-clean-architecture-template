using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Blogs.Dto
{
    public record BlogDto(int Id, string Name, string Description, string Author, string ImageUrl);
}
