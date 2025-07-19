using Clareia.Domain.Common;

namespace Clareia.Domain.Entities;

public class ColaboradorLeitura :
    AuditedBaseEntity<Guid>
{
    public Guid TermoId { get; private set; }
    public string ColaboradorEmail { get; private set; } = string.Empty; 
    public DateTime LidoEm { get; private set; }
    public bool Compreendido { get; private set; }

    protected ColaboradorLeitura()
    {
        TermoId = Guid.Empty;
        ColaboradorEmail = string.Empty;
        LidoEm = DateTime.UtcNow;
        Compreendido = false;
    }

    public ColaboradorLeitura(Guid termoId, string email, bool compreendido)
    {
        Id = Guid.NewGuid();
        TermoId = termoId;
        ColaboradorEmail = email;
        Compreendido = compreendido;
        LidoEm = DateTime.UtcNow;

        SetCreatedAt(DateTime.UtcNow);
        SetCreatedBy(email);
        SetUpdatedAt(DateTime.UtcNow);
        SetUpdatedBy(email);
    }

    public void MarcarComoCompreendido()
    {
        Compreendido = true;
    }

    public void MarcarComoNaoCompreendido()
    {
        Compreendido = false;
    }

    public void AtualizarLeitura(Guid termoId, string email, bool compreendido)
    {
        TermoId = termoId;
        ColaboradorEmail = email;
        Compreendido = compreendido;
        LidoEm = DateTime.UtcNow;
    }
}
