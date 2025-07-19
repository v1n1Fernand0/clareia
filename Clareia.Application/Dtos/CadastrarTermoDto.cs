namespace Clareia.Application.Dtos;
public class CadastrarTermoDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
    public DateTime? ExpiraEm { get; set; } = null;
}
