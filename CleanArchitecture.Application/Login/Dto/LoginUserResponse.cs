using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Login.Dto;

public class LoginUserResponse
{
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
}
