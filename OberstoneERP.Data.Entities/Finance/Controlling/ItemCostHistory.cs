namespace OberstoneERP.Data.Entities.Finance.Controlling;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents historical cost changes for an item, providing audit trail for cost updates.
/// </summary>
public class ItemCostHistory : BaseEntity
{
    /// <summary>
    /// Item cost record this history belongs to.
    /// </summary>
    public Guid ItemCostId { get; set; }

    /// <summary>
    /// Date and time of the cost change.
    /// </summary>
    public DateTime ChangeDate { get; set; }

    /// <summary>
    /// Type of cost change.
    /// </summary>
    public CostChangeType ChangeType { get; set; }

    /// <summary>
    /// Reason for the cost change.
    /// </summary>
    public string? ChangeReason { get; set; }

    /// <summary>
    /// Previous standard cost.
    /// </summary>
    public decimal PreviousStandardCost { get; set; }

    /// <summary>
    /// New standard cost.
    /// </summary>
    public decimal NewStandardCost { get; set; }

    /// <summary>
    /// Previous average cost.
    /// </summary>
    public decimal PreviousAverageCost { get; set; }

    /// <summary>
    /// New average cost.
    /// </summary>
    public decimal NewAverageCost { get; set; }

    /// <summary>
    /// Quantity on hand at time of change.
    /// </summary>
    public decimal QuantityOnHand { get; set; }

    /// <summary>
    /// Revaluation amount (quantity * cost difference).
    /// </summary>
    public decimal RevaluationAmount { get; set; }

    /// <summary>
    /// Source document type that triggered the change.
    /// </summary>
    public CostChangeSource? SourceType { get; set; }

    /// <summary>
    /// Source document ID.
    /// </summary>
    public Guid? SourceDocumentId { get; set; }

    /// <summary>
    /// Source document number for reference.
    /// </summary>
    public string? SourceDocumentNumber { get; set; }

    /// <summary>
    /// Associated journal entry ID for revaluation.
    /// </summary>
    public Guid? JournalEntryId { get; set; }

    /// <summary>
    /// Notes about the cost change.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual ItemCost ItemCost { get; set; } = null!;
}

/// <summary>
/// Types of cost changes.
/// </summary>
public enum CostChangeType
{
    /// <summary>
    /// Initial cost setup.
    /// </summary>
    Initial = 0,

    /// <summary>
    /// Standard cost update (periodic review).
    /// </summary>
    StandardCostUpdate = 1,

    /// <summary>
    /// Average cost recalculation from receipt.
    /// </summary>
    AverageCostRecalculation = 2,

    /// <summary>
    /// Manual adjustment.
    /// </summary>
    ManualAdjustment = 3,

    /// <summary>
    /// Year-end revaluation.
    /// </summary>
    YearEndRevaluation = 4,

    /// <summary>
    /// Cost rollup from BOM changes.
    /// </summary>
    CostRollup = 5,

    /// <summary>
    /// Currency revaluation.
    /// </summary>
    CurrencyRevaluation = 6,

    /// <summary>
    /// Inventory count adjustment.
    /// </summary>
    InventoryAdjustment = 7
}

/// <summary>
/// Sources that can trigger cost changes.
/// </summary>
public enum CostChangeSource
{
    /// <summary>
    /// Manual entry.
    /// </summary>
    Manual = 0,

    /// <summary>
    /// Purchase receipt.
    /// </summary>
    PurchaseReceipt = 1,

    /// <summary>
    /// Vendor invoice.
    /// </summary>
    VendorInvoice = 2,

    /// <summary>
    /// Production/work order completion.
    /// </summary>
    ProductionCompletion = 3,

    /// <summary>
    /// Standard cost update process.
    /// </summary>
    StandardCostUpdate = 4,

    /// <summary>
    /// Inventory adjustment.
    /// </summary>
    InventoryAdjustment = 5,

    /// <summary>
    /// System revaluation process.
    /// </summary>
    SystemRevaluation = 6
}
