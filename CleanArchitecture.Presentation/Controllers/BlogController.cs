using CleanArchitecture.Application.Blogs.Commands;
using CleanArchitecture.Application.Blogs.Queries;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation;

[Route("api/[controller]")]
[ApiController]
public class BlogController(IMediator _mediator) : ControllerBase
{

    /// <summary>
    /// Buscar todos registros de Blog
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<List<Blog>>> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllBlogsQuery()));
    }

    /// <summary>
    /// Busca Blog por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Blog>> GetById(int id)
    {
        return Ok((await _mediator.Send(new GetBlogByExpressionQuery(q => q.Id == id))).FirstOrDefault());
    }

    /// <summary>
    /// Gera um novo registro de Blog
    /// </summary>
    /// <param name="request">Dados a serem incluidos do Blog</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateBlogCommand request)
    {
        var id = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetById), new {id}, request);
    }

    /// <summary>
    /// Atualiza dados de um Blog
    /// </summary>
    /// <param name="req">Dados a serem atualizados do Blog</param>
    /// <param name="id">Identificador do blog</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Update([FromBody] UpdateBlogDto req, int id)
    {
        var command = new UpdateBlogCommand(id, req.Name, req.Description, req.Author, req.ImageUrl);
        if (!await _mediator.Send(command))
            return NotFound();
        return CreatedAtAction(nameof(GetById), new {id}, req);
    }

    /// <summary>
    /// Deletar Registro
    /// </summary>
    /// <param name="id">Identificador do blog a ser deletado</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteBlogCommand(id));
        if (!success)
            return NotFound();
        return NoContent();
    }
}
