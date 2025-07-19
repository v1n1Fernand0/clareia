using Clareia.Domain.Common;

public class ResumoIA : 
    AuditedBaseEntity<Guid>
{
    public Guid TermoId { get; private set; }
    public string TextoResumo { get; private set; }
    public DateTime GeradoEm { get; private set; }

    public ResumoIA(Guid termoId, string textoResumo)
    {
        Id = Guid.NewGuid();
        TermoId = termoId;
        TextoResumo = textoResumo;
        GeradoEm = DateTime.UtcNow;

        SetCreatedAt(DateTime.UtcNow);
        SetCreatedBy("system");
        SetUpdatedAt(DateTime.UtcNow);
        SetUpdatedBy("system"); 
    }
}
