using CleanArchitecture.Application.Blogs.UseCases.Commands.Create;
using CleanArchitecture.Application.Login.Dto;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Login.UseCases.Commands.LoginUser;

public class LoginUserHandler(IJwtTokenGenerator _jwtTokenGenerator) : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
{
    public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.NewGuid().ToString();
        var token = _jwtTokenGenerator.GenerateToken(userId, request.Email);
        return token;
    }
}
