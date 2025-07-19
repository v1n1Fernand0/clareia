using Clareia.Application.Dtos;
using Clareia.Domain.Entities;
using Clareia.Domain.Interfaces;

namespace Clareia.Application.Services;

public class TermoService : ITermoService
{
    private readonly IRepository<Termo, Guid> _termoRepo;

    public TermoService(IRepository<Termo, Guid> termoRepo)
    {
        _termoRepo = termoRepo;
    }

    public async Task CadastrarAsync(CadastrarTermoDto dto)
    {
        var termo = new Termo(dto.Titulo, dto.Conteudo, dto.ExpiraEm);
        termo.SetCreatedAt(DateTime.UtcNow);
        termo.SetCreatedBy("system");

        await _termoRepo.AddAsync(termo);
    }

    public async Task<IEnumerable<TermoDto>> ListarAsync()
    {
        var termos = await _termoRepo.GetAllAsync();
        return termos.Select(t => new TermoDto
        {
            Id = t.Id,
            Titulo = t.Titulo,
            CriadoEm = t.CriadoEm
        });
    }

    public async Task<TermoDto?> ObterPorIdAsync(Guid id)
    {
        var termo = await _termoRepo.GetByIdAsync(id);
        if (termo == null) return null;

        return new TermoDto
        {
            Id = termo.Id,
            Titulo = termo.Titulo,
            CriadoEm = termo.CriadoEm
        };
    }
}
