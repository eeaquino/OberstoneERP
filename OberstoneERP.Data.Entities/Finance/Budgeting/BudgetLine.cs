namespace OberstoneERP.Data.Entities.Finance.Budgeting;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents a budget line item for a specific fiscal period.
/// </summary>
public class BudgetLine : BaseEntity
{
    /// <summary>
    /// Budget this line belongs to.
    /// </summary>
    public Guid BudgetId { get; set; }

    /// <summary>
    /// Fiscal period this budget amount applies to.
    /// </summary>
    public Guid FiscalPeriodId { get; set; }

    /// <summary>
    /// Budgeted amount for this period.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Notes about this budget line.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Budget Budget { get; set; } = null!;
    public virtual FiscalPeriod FiscalPeriod { get; set; } = null!;
}
