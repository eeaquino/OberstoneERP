namespace OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a fiscal year for a company.
/// </summary>
public class FiscalYear : BaseEntity
{
    /// <summary>
    /// Company this fiscal year belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Name or label for the fiscal year (e.g., "FY2024").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Start date of the fiscal year.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// End date of the fiscal year.
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Status of the fiscal year.
    /// </summary>
    public FiscalYearStatus Status { get; set; } = FiscalYearStatus.Open;

    /// <summary>
    /// Indicates if this is the current active fiscal year.
    /// </summary>
    public bool IsCurrent { get; set; }

    /// <summary>
    /// Date when year-end closing was performed.
    /// </summary>
    public DateTime? ClosingDate { get; set; }

    /// <summary>
    /// User who performed the year-end closing.
    /// </summary>
    public Guid? ClosedBy { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual ICollection<FiscalPeriod> FiscalPeriods { get; set; } = [];
}

/// <summary>
/// Status of a fiscal year.
/// </summary>
public enum FiscalYearStatus
{
    NotStarted = 0,
    Open = 1,
    Closing = 2,
    Closed = 3,
    Locked = 4
}
