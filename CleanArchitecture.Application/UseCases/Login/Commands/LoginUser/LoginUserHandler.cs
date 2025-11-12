using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.UseCases.Login.Dto;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Login.Commands.LoginUser;

public class LoginUserHandler(IJwtTokenGenerator _jwtTokenGenerator,
                              IUserRepository _userRepository,
                              IPasswordHasher _hasher) : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
{
    public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(request.Email);
        if (user is not { } || !_hasher.Verify(user.PasswordHash, request.Password)) 
            return ErrorsDomain.UsuarioOuSenhaInvalidos;

        var roles = await _userRepository.GetUserRoles(user.Id);
        var token = _jwtTokenGenerator.GenerateToken(user.Id.ToString(), request.Email, [.. roles.Select(r => r.Name)]);
        return token;
    }
}
