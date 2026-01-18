namespace OberstoneERP.Data.Entities.Finance.FixedAssets;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents the disposal of a fixed asset.
/// </summary>
public class AssetDisposal : BaseEntity
{
    /// <summary>
    /// Company this disposal belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Asset being disposed.
    /// </summary>
    public Guid AssetId { get; set; }

    /// <summary>
    /// Unique disposal number.
    /// </summary>
    public string DisposalNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of disposal.
    /// </summary>
    public DateTime DisposalDate { get; set; }

    /// <summary>
    /// Type of disposal.
    /// </summary>
    public DisposalType DisposalType { get; set; }

    /// <summary>
    /// Reason for disposal.
    /// </summary>
    public string? DisposalReason { get; set; }

    /// <summary>
    /// Original cost at time of disposal.
    /// </summary>
    public decimal OriginalCost { get; set; }

    /// <summary>
    /// Accumulated depreciation at time of disposal.
    /// </summary>
    public decimal AccumulatedDepreciation { get; set; }

    /// <summary>
    /// Book value at time of disposal.
    /// </summary>
    public decimal BookValue { get; set; }

    /// <summary>
    /// Proceeds from disposal (sale price).
    /// </summary>
    public decimal DisposalProceeds { get; set; }

    /// <summary>
    /// Cost of disposal (removal, transportation, etc.).
    /// </summary>
    public decimal DisposalCosts { get; set; }

    /// <summary>
    /// Net proceeds (DisposalProceeds - DisposalCosts).
    /// </summary>
    public decimal NetProceeds => DisposalProceeds - DisposalCosts;

    /// <summary>
    /// Gain or loss on disposal.
    /// </summary>
    public decimal GainLoss { get; set; }

    /// <summary>
    /// Customer ID if sold to a customer.
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Status of the disposal.
    /// </summary>
    public DisposalStatus Status { get; set; } = DisposalStatus.Draft;

    /// <summary>
    /// Associated journal entry ID.
    /// </summary>
    public Guid? JournalEntryId { get; set; }

    /// <summary>
    /// User who approved the disposal.
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// Date the disposal was approved.
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// Notes about the disposal.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Asset Asset { get; set; } = null!;
}

/// <summary>
/// Types of asset disposal.
/// </summary>
public enum DisposalType
{
    /// <summary>
    /// Asset was sold.
    /// </summary>
    Sale = 0,

    /// <summary>
    /// Asset was scrapped.
    /// </summary>
    Scrap = 1,

    /// <summary>
    /// Asset was donated.
    /// </summary>
    Donation = 2,

    /// <summary>
    /// Asset was lost or stolen.
    /// </summary>
    LossOrTheft = 3,

    /// <summary>
    /// Asset was traded in.
    /// </summary>
    TradeIn = 4,

    /// <summary>
    /// Asset was written off.
    /// </summary>
    WriteOff = 5,

    /// <summary>
    /// Asset was transferred to another company.
    /// </summary>
    Transfer = 6,

    /// <summary>
    /// Other disposal type.
    /// </summary>
    Other = 99
}

/// <summary>
/// Status of an asset disposal.
/// </summary>
public enum DisposalStatus
{
    Draft = 0,
    PendingApproval = 1,
    Approved = 2,
    Posted = 3,
    Void = 4
}
