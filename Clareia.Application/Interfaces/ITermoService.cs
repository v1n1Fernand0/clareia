using Clareia.Application.Dtos;

public interface ITermoService
{
    Task CadastrarAsync(CadastrarTermoDto dto);
    Task<IEnumerable<TermoDto>> ListarAsync();
    Task<TermoDto?> ObterPorIdAsync(Guid id);
}
