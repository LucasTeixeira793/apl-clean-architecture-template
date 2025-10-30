using CleanArchitecture.Application.Login.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Login.UseCases.Commands.LoginUser
{
    public interface IJwtTokenGenerator
    {
        public LoginUserResponse GenerateToken(string userId, string email);
    }
}
