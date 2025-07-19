using Clareia.Domain.Common;

namespace Clareia.Domain.Entities;

public class Termo : AuditedBaseEntity<Guid>
{
    public string Titulo { get; private set; } = string.Empty; 
    public string Conteudo { get; private set; } = string.Empty;
    public DateTime CriadoEm { get; private set; }
    public DateTime? ExpiraEm { get; set; }

    protected Termo() { }

    public Termo(string titulo, string conteudo, DateTime? expiraEm)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Conteudo = conteudo;
        CriadoEm = DateTime.UtcNow;

        SetCreatedAt(DateTime.UtcNow);
        SetCreatedBy("system");
        SetUpdatedAt(DateTime.UtcNow);
        SetUpdatedBy("system");
        ExpiraEm = expiraEm;
    }
}
