namespace OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.Controlling;

/// <summary>
/// Represents a single line item within a journal entry.
/// </summary>
public class JournalEntryLine : BaseEntity
{
    /// <summary>
    /// Journal entry this line belongs to.
    /// </summary>
    public Guid JournalEntryId { get; set; }

    /// <summary>
    /// Account being debited or credited.
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// Line number within the journal entry.
    /// </summary>
    public int LineNumber { get; set; }

    /// <summary>
    /// Description for this line item.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Debit amount (zero if credit).
    /// </summary>
    public decimal DebitAmount { get; set; }

    /// <summary>
    /// Credit amount (zero if debit).
    /// </summary>
    public decimal CreditAmount { get; set; }

    /// <summary>
    /// Amount in the company's functional currency.
    /// </summary>
    public decimal FunctionalAmount { get; set; }

    /// <summary>
    /// Cost center ID for cost allocation.
    /// </summary>
    public Guid? CostCenterId { get; set; }

    /// <summary>
    /// Profit center ID for profit allocation.
    /// </summary>
    public Guid? ProfitCenterId { get; set; }

    /// <summary>
    /// Internal order ID for project tracking.
    /// </summary>
    public Guid? InternalOrderId { get; set; }

    /// <summary>
    /// Reference to a specific tax code.
    /// </summary>
    public Guid? TaxCodeId { get; set; }

    /// <summary>
    /// Tax amount if applicable.
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// Customer ID if this is an AR-related line.
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Vendor ID if this is an AP-related line.
    /// </summary>
    public Guid? VendorId { get; set; }

    /// <summary>
    /// Asset ID if this is an asset-related line.
    /// </summary>
    public Guid? AssetId { get; set; }

    /// <summary>
    /// Reconciliation status.
    /// </summary>
    public bool IsReconciled { get; set; }

    /// <summary>
    /// Date the line was reconciled.
    /// </summary>
    public DateTime? ReconciledDate { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual JournalEntry JournalEntry { get; set; } = null!;
    public virtual Account Account { get; set; } = null!;
    public virtual CostCenter? CostCenter { get; set; }
    public virtual ProfitCenter? ProfitCenter { get; set; }
    public virtual InternalOrder? InternalOrder { get; set; }
}
