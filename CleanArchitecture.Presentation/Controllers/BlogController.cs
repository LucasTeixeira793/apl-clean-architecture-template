using CleanArchitecture.Application.UseCases.Blogs.Commands.Create;
using CleanArchitecture.Application.UseCases.Blogs.Commands.Delete;
using CleanArchitecture.Application.UseCases.Blogs.Commands.Update;
using CleanArchitecture.Application.UseCases.Blogs.Queries.GetAll;
using CleanArchitecture.Application.UseCases.Blogs.Queries.GetByExpression;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin,Curioso")]
public class BlogController(IMediator _mediator) : ControllerBase
{

    /// <summary>
    /// Buscar todos registros de Blog
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<Result<List<Blog>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllBlogsQuery());
        return result.Match<ActionResult>(
            success: _ => Ok(result),
            failure: _ => NoContent());
    }

    /// <summary>
    /// Busca Blog por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Result<Blog>>> GetById(int id)
    {
        var result = await _mediator.Send(new GetSingleBlogByExpressionQuery(q => q.Id == id));
        return result.Match<ActionResult>(
                    success: _ => Ok(result),
                    failure: _ => NoContent());
    }

    /// <summary>
    /// Gera um novo registro de Blog
    /// </summary>
    /// <param name="request">Dados a serem incluidos do Blog</param>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateBlogCommand request)
    {
        var blog = await _mediator.Send(request);
        return blog.Match<IActionResult>
            (success: _ => CreatedAtAction(nameof(GetById), new { _.Id }, blog),
             failure: _ => StatusCode(422, blog));
    }

    /// <summary>
    /// Atualiza dados de um Blog
    /// </summary>
    /// <param name="req">Dados a serem atualizados do Blog</param>
    /// <param name="id">Identificador do blog</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] UpdateBlogDto req, int id)
    {
        var command = new UpdateBlogCommand(id, req.Name, req.Description, req.Author, req.ImageUrl);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            success: _ => CreatedAtAction(nameof(GetById), new { _.Id }, req),
            failure: _ => StatusCode(404, result));
    }

    /// <summary>
    /// Deletar Registro
    /// </summary>
    /// <param name="id">Identificador do blog a ser deletado</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteBlogCommand(id));
        return result.Match<IActionResult>(
            success: _ => NoContent(),
            failure: _ => StatusCode(404, result));
    }
}
