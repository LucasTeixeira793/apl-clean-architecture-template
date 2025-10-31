using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.UseCases.Login.Dto;
using CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Login.Commands.LoginUser;

public class LoginUserHandler(IJwtTokenGenerator _jwtTokenGenerator) : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
{
    public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.NewGuid().ToString();
        var token = _jwtTokenGenerator.GenerateToken(userId, request.Email);
        return token;
    }
}
