namespace OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Base entity class providing common audit fields and tenant isolation for all ERP entities.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Primary key identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Tenant identifier for multi-tenant isolation.
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Date and time when the entity was created (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Identifier of the user who created the entity.
    /// </summary>
    public Guid CreatedBy { get; set; }

    /// <summary>
    /// Date and time when the entity was last modified (UTC).
    /// </summary>
    public DateTime? ModifiedAt { get; set; }

    /// <summary>
    /// Identifier of the user who last modified the entity.
    /// </summary>
    public Guid? ModifiedBy { get; set; }

    /// <summary>
    /// Indicates whether the entity is soft-deleted.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Date and time when the entity was soft-deleted (UTC).
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// Identifier of the user who soft-deleted the entity.
    /// </summary>
    public Guid? DeletedBy { get; set; }

    /// <summary>
    /// Row version for optimistic concurrency control.
    /// </summary>
    public byte[] RowVersion { get; set; } = [];
}
