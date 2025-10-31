using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Login.Dto;
using CleanArchitecture.Domain.Abstractions;
using MediatR;

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
