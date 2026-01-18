namespace OberstoneERP.Data.Entities.Finance.Intercompany;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.Entities.Finance.Controlling;

/// <summary>
/// Represents a line item on an intercompany transaction.
/// </summary>
public class IntercompanyTransactionLine : BaseEntity
{
    /// <summary>
    /// Transaction this line belongs to.
    /// </summary>
    public Guid IntercompanyTransactionId { get; set; }

    /// <summary>
    /// Line number within the transaction.
    /// </summary>
    public int LineNumber { get; set; }

    /// <summary>
    /// Description of the line item.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Item/product code (if applicable).
    /// </summary>
    public string? ItemCode { get; set; }

    /// <summary>
    /// Account ID in source company.
    /// </summary>
    public Guid SourceAccountId { get; set; }

    /// <summary>
    /// Account ID in target company.
    /// </summary>
    public Guid TargetAccountId { get; set; }

    /// <summary>
    /// Quantity.
    /// </summary>
    public decimal Quantity { get; set; } = 1;

    /// <summary>
    /// Unit of measure.
    /// </summary>
    public string? UnitOfMeasure { get; set; }

    /// <summary>
    /// Unit price.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Line amount.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Cost center ID in source company.
    /// </summary>
    public Guid? SourceCostCenterId { get; set; }

    /// <summary>
    /// Profit center ID in source company.
    /// </summary>
    public Guid? SourceProfitCenterId { get; set; }

    /// <summary>
    /// Cost center ID in target company.
    /// </summary>
    public Guid? TargetCostCenterId { get; set; }

    /// <summary>
    /// Profit center ID in target company.
    /// </summary>
    public Guid? TargetProfitCenterId { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual IntercompanyTransaction IntercompanyTransaction { get; set; } = null!;
    public virtual Account SourceAccount { get; set; } = null!;
    public virtual Account TargetAccount { get; set; } = null!;
    public virtual CostCenter? SourceCostCenter { get; set; }
    public virtual ProfitCenter? SourceProfitCenter { get; set; }
    public virtual CostCenter? TargetCostCenter { get; set; }
    public virtual ProfitCenter? TargetProfitCenter { get; set; }
}
