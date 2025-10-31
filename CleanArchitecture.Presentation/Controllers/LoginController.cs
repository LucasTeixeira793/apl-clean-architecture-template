using CleanArchitecture.Application.UseCases.Login.Commands.LoginUser;
using CleanArchitecture.Application.UseCases.Login.Dto;
using CleanArchitecture.Application.Validators;
using CleanArchitecture.Domain.Abstractions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class LoginController(IMediator _mediator,
                             IValidator<LoginDto> _validator) : ControllerBase
{

    /// <summary>
    /// Realiza login
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Result>> Login([FromBody] LoginDto login)
    {
        var validation = _validator.ValidateResult(login);
        if (!_validator.ValidateResult(login).IsSuccess) return validation;

        var result = await _mediator.Send(new LoginUserCommand(login.Email, login.Password));
        return result.Match<ActionResult>(
            success: _ => Ok(result),
            failure: _ => BadRequest(result));
    }
}