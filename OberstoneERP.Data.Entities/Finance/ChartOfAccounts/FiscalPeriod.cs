namespace OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a fiscal period (typically a month) within a fiscal year.
/// </summary>
public class FiscalPeriod : BaseEntity
{
    /// <summary>
    /// Fiscal year this period belongs to.
    /// </summary>
    public Guid FiscalYearId { get; set; }

    /// <summary>
    /// Period number within the fiscal year (1-12 for monthly, 1-4 for quarterly, etc.).
    /// </summary>
    public int PeriodNumber { get; set; }

    /// <summary>
    /// Name of the period (e.g., "January 2024", "Q1 2024").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Start date of the period.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// End date of the period.
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Status of the period.
    /// </summary>
    public FiscalPeriodStatus Status { get; set; } = FiscalPeriodStatus.Open;

    /// <summary>
    /// Indicates if this is a special adjustment period (period 13).
    /// </summary>
    public bool IsAdjustmentPeriod { get; set; }

    /// <summary>
    /// Date when the period was closed.
    /// </summary>
    public DateTime? ClosingDate { get; set; }

    /// <summary>
    /// User who closed the period.
    /// </summary>
    public Guid? ClosedBy { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual FiscalYear FiscalYear { get; set; } = null!;
    public virtual ICollection<JournalEntry> JournalEntries { get; set; } = [];
}

/// <summary>
/// Status of a fiscal period.
/// </summary>
public enum FiscalPeriodStatus
{
    NotStarted = 0,
    Open = 1,
    SoftClose = 2,
    Closed = 3,
    Locked = 4
}
