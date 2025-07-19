using Clareia.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Clareia.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeiturasController : ControllerBase
{
    private readonly ILeituraService _leituraService;

    public LeiturasController(ILeituraService leituraService)
    {
        _leituraService = leituraService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RegistrarLeituraDto dto)
    {
        await _leituraService.RegistrarAsync(dto);
        return Created("", dto);
    }

    [HttpGet("por-termo/{termoId}")]
    public async Task<IActionResult> GetByTermo(Guid termoId)
    {
        var leituras = await _leituraService.ListarPorTermoAsync(termoId);
        return Ok(leituras);
    }

    [HttpGet("por-colaborador/{email}")]
    public async Task<IActionResult> GetByColaborador(string email)
    {
        var leituras = await _leituraService.ListarPorColaboradorAsync(email);
        return Ok(leituras);
    }
}
