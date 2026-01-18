namespace OberstoneERP.Data.Entities.Finance.Budgeting;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.Entities.Finance.Controlling;

/// <summary>
/// Represents a budget entry for a specific account, cost center, and period combination.
/// </summary>
public class Budget : BaseEntity
{
    /// <summary>
    /// Budget version this entry belongs to.
    /// </summary>
    public Guid BudgetVersionId { get; set; }

    /// <summary>
    /// Account being budgeted.
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// Cost center (optional).
    /// </summary>
    public Guid? CostCenterId { get; set; }

    /// <summary>
    /// Profit center (optional).
    /// </summary>
    public Guid? ProfitCenterId { get; set; }

    /// <summary>
    /// Site (optional).
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Total annual budget amount.
    /// </summary>
    public decimal AnnualAmount { get; set; }

    /// <summary>
    /// Notes about the budget entry.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual BudgetVersion BudgetVersion { get; set; } = null!;
    public virtual Account Account { get; set; } = null!;
    public virtual CostCenter? CostCenter { get; set; }
    public virtual ProfitCenter? ProfitCenter { get; set; }
    public virtual Site? Site { get; set; }
    public virtual ICollection<BudgetLine> Lines { get; set; } = [];
}
