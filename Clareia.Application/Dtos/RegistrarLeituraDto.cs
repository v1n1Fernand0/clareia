namespace Clareia.Application.Dtos;
public class RegistrarLeituraDto
{
    public Guid TermoId { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool Compreendido { get; set; }
}
