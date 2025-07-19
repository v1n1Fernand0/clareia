namespace Clareia.Application.Dtos;
public class TermoDto
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; }
}
