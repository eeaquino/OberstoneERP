namespace OberstoneERP.Data.Entities.Finance.Budgeting;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents a budget version (scenario) for a fiscal year.
/// </summary>
public class BudgetVersion : BaseEntity
{
    /// <summary>
    /// Company this budget version belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Fiscal year this budget is for.
    /// </summary>
    public Guid FiscalYearId { get; set; }

    /// <summary>
    /// Unique code for the budget version.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the budget version.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the budget version.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Type of budget version.
    /// </summary>
    public BudgetVersionType VersionType { get; set; }

    /// <summary>
    /// Status of the budget version.
    /// </summary>
    public BudgetVersionStatus Status { get; set; } = BudgetVersionStatus.Draft;

    /// <summary>
    /// Indicates if this is the active budget version for the fiscal year.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Currency ID for the budget.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// Date the budget was finalized/approved.
    /// </summary>
    public DateTime? ApprovedDate { get; set; }

    /// <summary>
    /// User who approved the budget.
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// Notes about the budget version.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual FiscalYear FiscalYear { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
    public virtual ICollection<Budget> Budgets { get; set; } = [];
}

/// <summary>
/// Types of budget versions.
/// </summary>
public enum BudgetVersionType
{
    /// <summary>
    /// Original approved budget.
    /// </summary>
    Original = 0,

    /// <summary>
    /// Revised budget.
    /// </summary>
    Revised = 1,

    /// <summary>
    /// Forecast/projection.
    /// </summary>
    Forecast = 2,

    /// <summary>
    /// What-if scenario.
    /// </summary>
    Scenario = 3,

    /// <summary>
    /// Rolling forecast.
    /// </summary>
    Rolling = 4
}

/// <summary>
/// Status of a budget version.
/// </summary>
public enum BudgetVersionStatus
{
    Draft = 0,
    InReview = 1,
    PendingApproval = 2,
    Approved = 3,
    Active = 4,
    Superseded = 5,
    Archived = 6
}
