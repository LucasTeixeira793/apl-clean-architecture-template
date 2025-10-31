using CleanArchitecture.Application.Login.Dto;
using CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Application.Login.UseCases.Commands.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest<Result<LoginUserResponse>>;
