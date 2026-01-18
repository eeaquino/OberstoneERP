namespace OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a physical or logical site/location within a company.
/// Sites can represent warehouses, branches, stores, or any operational location.
/// </summary>
public class Site : BaseEntity
{
    /// <summary>
    /// Company this site belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Unique code identifying the site within the company.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the site.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the site.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Type of site (e.g., Headquarters, Branch, Warehouse, Store).
    /// </summary>
    public SiteType SiteType { get; set; }

    /// <summary>
    /// Primary address line.
    /// </summary>
    public string? AddressLine1 { get; set; }

    /// <summary>
    /// Secondary address line.
    /// </summary>
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// City.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// State or province.
    /// </summary>
    public string? StateProvince { get; set; }

    /// <summary>
    /// Postal or ZIP code.
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// Country code (ISO 3166-1 alpha-2).
    /// </summary>
    public string? CountryCode { get; set; }

    /// <summary>
    /// Site's timezone identifier (e.g., "America/New_York").
    /// </summary>
    public string? TimeZoneId { get; set; }

    /// <summary>
    /// Primary contact email for the site.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Primary contact phone number.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Indicates whether the site is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Sort order for display purposes.
    /// </summary>
    public int SortOrder { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
}

/// <summary>
/// Types of sites in the ERP system.
/// </summary>
public enum SiteType
{
    Headquarters = 0,
    Branch = 1,
    Warehouse = 2,
    Store = 3,
    Factory = 4,
    Office = 5,
    Distribution = 6,
    Other = 99
}
