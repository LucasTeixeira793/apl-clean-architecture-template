using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation;

[Route("api/[controller]")]
[ApiController]
public class BlogController(IBlogService _blogService) : ControllerBase
{
    /// <summary>
    /// Buscar todos registros
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<List<Blog>>> GetAll()
    {
        return Ok(await _blogService.GetAllAsync());
    }


    [HttpGet("[action]")]
    public async Task<ActionResult<Blog>> GetById([FromQuery] int id)
    {
        return Ok(await _blogService.GetByIdAsync(id));
    }
        

    [HttpPost("[action]")]
    public async Task<ActionResult<int>> Create([FromBody] Blog request)
    {
        return Ok(await _blogService.CreateAsync(request));
    }


    [HttpPut("[action]/{id}")]
    public async Task<ActionResult<int>> Update([FromBody] Blog request, int id)
    {
        return Ok(await _blogService.UpdateAsync(request, id));
    }

    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        return Ok(await _blogService.DeleteAsync(id));
    }
    
}
