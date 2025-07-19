using Clareia.Domain.Interfaces;

namespace Clareia.Domain.Common;

public abstract class AuditedBaseEntity<TKey> : IAuditedBaseEntity<TKey> where TKey : struct
{
    public TKey Id { get; protected set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public string CreatedBy { get; private set; } = string.Empty;
    public string? UpdatedBy { get; private set; }

    public void SetCreatedAt(DateTime createdAt) => CreatedAt = createdAt;
    public void SetUpdatedAt(DateTime updatedAt) => UpdatedAt = updatedAt;
    public void SetCreatedBy(string createdBy) => CreatedBy = createdBy;
    public void SetUpdatedBy(string? updatedBy) => UpdatedBy = updatedBy;
}
