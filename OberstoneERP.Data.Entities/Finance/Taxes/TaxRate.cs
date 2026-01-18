namespace OberstoneERP.Data.Entities.Finance.Taxes;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a tax rate for a tax code, effective for a specific date range.
/// </summary>
public class TaxRate : BaseEntity
{
    /// <summary>
    /// Tax code this rate belongs to.
    /// </summary>
    public Guid TaxCodeId { get; set; }

    /// <summary>
    /// Date the rate becomes effective.
    /// </summary>
    public DateTime EffectiveFrom { get; set; }

    /// <summary>
    /// Date the rate expires (null = no expiration).
    /// </summary>
    public DateTime? EffectiveTo { get; set; }

    /// <summary>
    /// Tax rate percentage.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// Minimum taxable amount (threshold).
    /// </summary>
    public decimal? MinimumAmount { get; set; }

    /// <summary>
    /// Maximum taxable amount (cap).
    /// </summary>
    public decimal? MaximumAmount { get; set; }

    /// <summary>
    /// Fixed tax amount per unit (for specific taxes).
    /// </summary>
    public decimal? FixedAmount { get; set; }

    /// <summary>
    /// Description or notes about this rate.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Indicates whether this rate is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual TaxCode TaxCode { get; set; } = null!;
}
