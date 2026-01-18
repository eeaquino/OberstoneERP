namespace OberstoneERP.Data.Entities.Finance.FixedAssets;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents a depreciation transaction for a fixed asset.
/// </summary>
public class AssetDepreciation : BaseEntity
{
    /// <summary>
    /// Asset being depreciated.
    /// </summary>
    public Guid AssetId { get; set; }

    /// <summary>
    /// Fiscal period the depreciation is recorded in.
    /// </summary>
    public Guid FiscalPeriodId { get; set; }

    /// <summary>
    /// Date of the depreciation entry.
    /// </summary>
    public DateTime DepreciationDate { get; set; }

    /// <summary>
    /// Depreciation amount for this period.
    /// </summary>
    public decimal DepreciationAmount { get; set; }

    /// <summary>
    /// Accumulated depreciation after this entry.
    /// </summary>
    public decimal AccumulatedDepreciation { get; set; }

    /// <summary>
    /// Book value after this entry.
    /// </summary>
    public decimal BookValue { get; set; }

    /// <summary>
    /// Type of depreciation entry.
    /// </summary>
    public DepreciationEntryType EntryType { get; set; } = DepreciationEntryType.Normal;

    /// <summary>
    /// Status of the depreciation entry.
    /// </summary>
    public DepreciationStatus Status { get; set; } = DepreciationStatus.Calculated;

    /// <summary>
    /// Associated journal entry ID.
    /// </summary>
    public Guid? JournalEntryId { get; set; }

    /// <summary>
    /// Notes about this depreciation entry.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Asset Asset { get; set; } = null!;
    public virtual FiscalPeriod FiscalPeriod { get; set; } = null!;
}

/// <summary>
/// Types of depreciation entries.
/// </summary>
public enum DepreciationEntryType
{
    /// <summary>
    /// Normal periodic depreciation.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// Adjustment to depreciation.
    /// </summary>
    Adjustment = 1,

    /// <summary>
    /// Catch-up depreciation.
    /// </summary>
    CatchUp = 2,

    /// <summary>
    /// Impairment write-down.
    /// </summary>
    Impairment = 3,

    /// <summary>
    /// Reversal of previous depreciation.
    /// </summary>
    Reversal = 4
}

/// <summary>
/// Status of a depreciation entry.
/// </summary>
public enum DepreciationStatus
{
    /// <summary>
    /// Depreciation has been calculated but not posted.
    /// </summary>
    Calculated = 0,

    /// <summary>
    /// Depreciation has been posted to the general ledger.
    /// </summary>
    Posted = 1,

    /// <summary>
    /// Depreciation entry has been reversed.
    /// </summary>
    Reversed = 2
}
