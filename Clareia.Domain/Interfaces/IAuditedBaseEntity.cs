namespace Clareia.Domain.Interfaces
{
    public interface IAuditedBaseEntity<TKey>
        where TKey : struct
    {
        TKey Id { get; }
        DateTime CreatedAt { get; }
        DateTime? UpdatedAt { get; }
        string CreatedBy { get; }
        string? UpdatedBy { get; }
        
        void SetCreatedAt(DateTime createdAt);
        void SetUpdatedAt(DateTime updatedAt);
        void SetCreatedBy(string createdBy);
        void SetUpdatedBy(string? updatedBy);
    }
}
