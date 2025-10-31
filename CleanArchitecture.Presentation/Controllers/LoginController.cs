using CleanArchitecture.Application.Login.Dto;
using CleanArchitecture.Application.Login.UseCases.Commands.LoginUser;
using CleanArchitecture.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class LoginController(IMediator _mediator) : ControllerBase
{

    /// <summary>
    /// Realiza login
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Result<LoginUserResponse>>> Login([FromBody] LoginUserRequest login)
    {
        var result = await _mediator.Send(new LoginUserCommand(login.Email, login.Password));
        return result.Match<ActionResult>(
            success: _ => Ok(result),
            failure: _ => NoContent());
    }
}