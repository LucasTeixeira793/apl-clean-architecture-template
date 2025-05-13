using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Abstractions
{
    public record Error(string Code, string Description)
    {
        //public TypeError ErrorType { get; set; }
    }
}
