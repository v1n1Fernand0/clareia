using Clareia.Application.Dtos;

public interface ILeituraService
{
    Task RegistrarAsync(RegistrarLeituraDto dto);
    Task<IEnumerable<LeituraDto>> ListarPorTermoAsync(Guid termoId);
    Task<IEnumerable<LeituraDto>> ListarPorColaboradorAsync(string email);
}
