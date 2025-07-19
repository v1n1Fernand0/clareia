namespace Clareia.Application.Dtos;
public class LeituraDto
{
    public Guid Id { get; set; }
    public Guid TermoId { get; set; }
    public string ColaboradorEmail { get; set; } = string.Empty;
    public DateTime LidoEm { get; set; }
    public bool Compreendido { get; set; }
}
