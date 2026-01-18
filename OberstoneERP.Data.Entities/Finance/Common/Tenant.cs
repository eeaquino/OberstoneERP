namespace OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a tenant in the multi-tenant ERP system.
/// A tenant is the highest level of isolation, typically representing a separate organization or subscription.
/// </summary>
public class Tenant
{
    /// <summary>
    /// Primary key identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Unique code identifying the tenant.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the tenant/organization.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Legal name of the organization.
    /// </summary>
    public string? LegalName { get; set; }

    /// <summary>
    /// Primary contact email for the tenant.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Primary contact phone number.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Tenant's default timezone identifier (e.g., "America/New_York").
    /// </summary>
    public string TimeZoneId { get; set; } = "UTC";

    /// <summary>
    /// Default locale/culture for the tenant (e.g., "en-US").
    /// </summary>
    public string Locale { get; set; } = "en-US";

    /// <summary>
    /// Indicates whether the tenant is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Date and time when the tenant was created (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date and time when the tenant was last modified (UTC).
    /// </summary>
    public DateTime? ModifiedAt { get; set; }

    /// <summary>
    /// Row version for optimistic concurrency control.
    /// </summary>
    public byte[] RowVersion { get; set; } = [];

    // Navigation properties
    public virtual ICollection<Company> Companies { get; set; } = [];
    public virtual ICollection<Site> Sites { get; set; } = [];
    public virtual ICollection<Currency> Currencies { get; set; } = [];
}
