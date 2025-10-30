using CleanArchitecture.Application.Login.Dto;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Login.UseCases.Commands.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest<Result<LoginUserResponse>>;
