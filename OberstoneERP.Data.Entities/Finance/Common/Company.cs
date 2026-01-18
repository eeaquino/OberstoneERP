namespace OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a company within a tenant.
/// A company is a legal entity with its own chart of accounts, fiscal periods, and financial reporting.
/// </summary>
public class Company : BaseEntity
{
    /// <summary>
    /// Unique code identifying the company within the tenant.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the company.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Legal registered name of the company.
    /// </summary>
    public string? LegalName { get; set; }

    /// <summary>
    /// Tax identification number (e.g., EIN, VAT number).
    /// </summary>
    public string? TaxId { get; set; }

    /// <summary>
    /// Company registration number.
    /// </summary>
    public string? RegistrationNumber { get; set; }

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
    /// Primary contact email.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Primary contact phone number.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Company website URL.
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// Default currency ID for the company (functional currency).
    /// </summary>
    public Guid DefaultCurrencyId { get; set; }

    /// <summary>
    /// Fiscal year start month (1-12).
    /// </summary>
    public int FiscalYearStartMonth { get; set; } = 1;

    /// <summary>
    /// Fiscal year start day (1-31).
    /// </summary>
    public int FiscalYearStartDay { get; set; } = 1;

    /// <summary>
    /// Default inventory costing method for the company.
    /// </summary>
    public CostingMethod DefaultCostingMethod { get; set; } = CostingMethod.AverageCosting;

    /// <summary>
    /// Indicates whether the company is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Currency DefaultCurrency { get; set; } = null!;
    public virtual ICollection<Site> Sites { get; set; } = [];
}

/// <summary>
/// Inventory costing methods supported by the ERP system.
/// </summary>
public enum CostingMethod
{
    /// <summary>
    /// Standard costing - predefined costs with variance tracking.
    /// </summary>
    StandardCosting = 0,

    /// <summary>
    /// Weighted average costing - cost recalculated on each receipt.
    /// </summary>
    AverageCosting = 1,

    /// <summary>
    /// Moving average costing - continuously updated average cost.
    /// </summary>
    MovingAverageCosting = 2,

    /// <summary>
    /// First In First Out costing.
    /// </summary>
    FIFO = 3,

    /// <summary>
    /// Last In First Out costing.
    /// </summary>
    LIFO = 4,

    /// <summary>
    /// Specific identification costing (for serialized items).
    /// </summary>
    SpecificIdentification = 5
}
