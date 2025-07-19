using Clareia.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Clareia.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TermosController : ControllerBase
{
    private readonly ITermoService _termoService;

    public TermosController(ITermoService termoService)
    {
        _termoService = termoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var termos = await _termoService.ListarAsync();
        return Ok(termos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var termo = await _termoService.ObterPorIdAsync(id);
        return termo == null ? NotFound() : Ok(termo);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CadastrarTermoDto dto)
    {
        await _termoService.CadastrarAsync(dto);
        return Created("", dto); 
    }
}
