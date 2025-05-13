using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Abstractions
{
    public class Result
    {
        public bool IsSuccess { get; set; } = true;
        public List<Error>? Errors { get; set; }

        public void NewError(Error error)
        {
            Errors.Add(error);
        }
    }
}
