namespace OberstoneERP.Data.Entities.Finance.Budgeting;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.Entities.Finance.Controlling;

/// <summary>
/// Represents a budget transfer between accounts, cost centers, or periods.
/// </summary>
public class BudgetTransfer : BaseEntity
{
    /// <summary>
    /// Company this transfer belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Budget version this transfer applies to.
    /// </summary>
    public Guid BudgetVersionId { get; set; }

    /// <summary>
    /// Unique transfer number.
    /// </summary>
    public string TransferNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of the transfer.
    /// </summary>
    public DateTime TransferDate { get; set; }

    /// <summary>
    /// Description/reason for the transfer.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Source account ID.
    /// </summary>
    public Guid FromAccountId { get; set; }

    /// <summary>
    /// Source cost center ID.
    /// </summary>
    public Guid? FromCostCenterId { get; set; }

    /// <summary>
    /// Source fiscal period ID.
    /// </summary>
    public Guid FromFiscalPeriodId { get; set; }

    /// <summary>
    /// Destination account ID.
    /// </summary>
    public Guid ToAccountId { get; set; }

    /// <summary>
    /// Destination cost center ID.
    /// </summary>
    public Guid? ToCostCenterId { get; set; }

    /// <summary>
    /// Destination fiscal period ID.
    /// </summary>
    public Guid ToFiscalPeriodId { get; set; }

    /// <summary>
    /// Amount being transferred.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Status of the transfer.
    /// </summary>
    public BudgetTransferStatus Status { get; set; } = BudgetTransferStatus.Draft;

    /// <summary>
    /// User who approved the transfer.
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// Date the transfer was approved.
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// Notes about the transfer.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual BudgetVersion BudgetVersion { get; set; } = null!;
    public virtual Account FromAccount { get; set; } = null!;
    public virtual Account ToAccount { get; set; } = null!;
    public virtual CostCenter? FromCostCenter { get; set; }
    public virtual CostCenter? ToCostCenter { get; set; }
    public virtual FiscalPeriod FromFiscalPeriod { get; set; } = null!;
    public virtual FiscalPeriod ToFiscalPeriod { get; set; } = null!;
}

/// <summary>
/// Status of a budget transfer.
/// </summary>
public enum BudgetTransferStatus
{
    Draft = 0,
    PendingApproval = 1,
    Approved = 2,
    Posted = 3,
    Rejected = 4,
    Void = 5
}
