using CleanArchitecture.Application.UseCases.UselessFacts.Queries.Random;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FactsController(IMediator _mediator) : ControllerBase
{

    /// <summary>
    /// Buscar todos registros de Blog
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<Result<UselessFact>>> Random()
    {
        var result = await _mediator.Send(new GetRandomFactQuery());
        return result.Match<ActionResult>(
            success: _ => Ok(result),
            failure: _ => BadRequest(result));
    }
}
