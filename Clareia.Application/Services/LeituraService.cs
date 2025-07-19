using Clareia.Application.Dtos;
using Clareia.Domain.Entities;
using Clareia.Domain.Interfaces;

namespace Clareia.Application.Services;

public class LeituraService : ILeituraService
{
    private readonly IRepository<ColaboradorLeitura, Guid> _leituraRepo;

    public LeituraService(IRepository<ColaboradorLeitura, Guid> leituraRepo)
    {
        _leituraRepo = leituraRepo;
    }

    public async Task RegistrarAsync(RegistrarLeituraDto dto)
    {
        var leitura = new ColaboradorLeitura(dto.TermoId, dto.Email, dto.Compreendido);
        leitura.SetCreatedAt(DateTime.UtcNow);
        leitura.SetCreatedBy(dto.Email);

        await _leituraRepo.AddAsync(leitura);
    }

    public async Task<IEnumerable<LeituraDto>> ListarPorTermoAsync(Guid termoId)
    {
        var leituras = await _leituraRepo.FindAsync(x => x.TermoId == termoId);

        return leituras.Select(l => new LeituraDto
        {
            Id = l.Id,
            TermoId = l.TermoId,
            ColaboradorEmail = l.ColaboradorEmail,
            LidoEm = l.LidoEm,
            Compreendido = l.Compreendido
        });
    }

    public async Task<IEnumerable<LeituraDto>> ListarPorColaboradorAsync(string email)
    {
        var leituras = await _leituraRepo.FindAsync(x => x.ColaboradorEmail == email);

        return leituras.Select(l => new LeituraDto
        {
            Id = l.Id,
            TermoId = l.TermoId,
            ColaboradorEmail = l.ColaboradorEmail,
            LidoEm = l.LidoEm,
            Compreendido = l.Compreendido
        });
    }
}
