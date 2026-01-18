namespace OberstoneERP.Data.Entities.Finance.Controlling;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents an internal order for tracking costs of specific activities, projects, or events.
/// </summary>
public class InternalOrder : BaseEntity
{
    /// <summary>
    /// Company this internal order belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Site this internal order is associated with.
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Unique order number.
    /// </summary>
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>
    /// Name/description of the internal order.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Detailed description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Type of internal order.
    /// </summary>
    public InternalOrderType OrderType { get; set; }

    /// <summary>
    /// Category for grouping orders.
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Responsible cost center ID.
    /// </summary>
    public Guid? ResponsibleCostCenterId { get; set; }

    /// <summary>
    /// Manager responsible for this order.
    /// </summary>
    public Guid? ManagerId { get; set; }

    /// <summary>
    /// Planned start date.
    /// </summary>
    public DateTime? PlannedStartDate { get; set; }

    /// <summary>
    /// Planned end date.
    /// </summary>
    public DateTime? PlannedEndDate { get; set; }

    /// <summary>
    /// Actual start date.
    /// </summary>
    public DateTime? ActualStartDate { get; set; }

    /// <summary>
    /// Actual end date.
    /// </summary>
    public DateTime? ActualEndDate { get; set; }

    /// <summary>
    /// Currency ID.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// Budgeted/planned cost.
    /// </summary>
    public decimal PlannedCost { get; set; }

    /// <summary>
    /// Actual costs accumulated.
    /// </summary>
    public decimal ActualCost { get; set; }

    /// <summary>
    /// Committed costs (purchase orders, etc.).
    /// </summary>
    public decimal CommittedCost { get; set; }

    /// <summary>
    /// Available budget (Planned - Actual - Committed).
    /// </summary>
    public decimal AvailableBudget => PlannedCost - ActualCost - CommittedCost;

    /// <summary>
    /// Planned revenue (if applicable).
    /// </summary>
    public decimal PlannedRevenue { get; set; }

    /// <summary>
    /// Actual revenue (if applicable).
    /// </summary>
    public decimal ActualRevenue { get; set; }

    /// <summary>
    /// Status of the internal order.
    /// </summary>
    public InternalOrderStatus Status { get; set; } = InternalOrderStatus.Created;

    /// <summary>
    /// Indicates if posting is allowed.
    /// </summary>
    public bool AllowPosting { get; set; } = true;

    /// <summary>
    /// Indicates if the order is subject to budget control.
    /// </summary>
    public bool BudgetControlEnabled { get; set; } = true;

    /// <summary>
    /// Settlement cost center ID (where costs are settled to).
    /// </summary>
    public Guid? SettlementCostCenterId { get; set; }

    /// <summary>
    /// Settlement rule percentage.
    /// </summary>
    public decimal SettlementPercent { get; set; } = 100;

    /// <summary>
    /// Date the order was closed.
    /// </summary>
    public DateTime? ClosedDate { get; set; }

    /// <summary>
    /// Notes about the internal order.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Site? Site { get; set; }
    public virtual Currency Currency { get; set; } = null!;
    public virtual CostCenter? ResponsibleCostCenter { get; set; }
    public virtual CostCenter? SettlementCostCenter { get; set; }
}

/// <summary>
/// Types of internal orders.
/// </summary>
public enum InternalOrderType
{
    /// <summary>
    /// Overhead/administrative order.
    /// </summary>
    Overhead = 0,

    /// <summary>
    /// Investment/capital order.
    /// </summary>
    Investment = 1,

    /// <summary>
    /// Maintenance order.
    /// </summary>
    Maintenance = 2,

    /// <summary>
    /// Marketing/campaign order.
    /// </summary>
    Marketing = 3,

    /// <summary>
    /// Training order.
    /// </summary>
    Training = 4,

    /// <summary>
    /// Research and development order.
    /// </summary>
    Research = 5,

    /// <summary>
    /// Project order.
    /// </summary>
    Project = 6,

    /// <summary>
    /// Service order.
    /// </summary>
    Service = 7,

    /// <summary>
    /// Other type of order.
    /// </summary>
    Other = 99
}

/// <summary>
/// Status of an internal order.
/// </summary>
public enum InternalOrderStatus
{
    /// <summary>
    /// Order has been created.
    /// </summary>
    Created = 0,

    /// <summary>
    /// Order has been released for use.
    /// </summary>
    Released = 1,

    /// <summary>
    /// Order is in progress.
    /// </summary>
    InProgress = 2,

    /// <summary>
    /// Order is technically complete.
    /// </summary>
    TechnicallyComplete = 3,

    /// <summary>
    /// Order is closed.
    /// </summary>
    Closed = 4,

    /// <summary>
    /// Order is locked (no further posting).
    /// </summary>
    Locked = 5,

    /// <summary>
    /// Order has been cancelled.
    /// </summary>
    Cancelled = 6
}
