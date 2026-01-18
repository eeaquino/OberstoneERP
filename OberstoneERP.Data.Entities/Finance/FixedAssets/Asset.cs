namespace OberstoneERP.Data.Entities.Finance.FixedAssets;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a fixed asset.
/// </summary>
public class Asset : BaseEntity
{
    /// <summary>
    /// Company this asset belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Site where the asset is located.
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Asset category ID.
    /// </summary>
    public Guid AssetCategoryId { get; set; }

    /// <summary>
    /// Unique asset number/tag.
    /// </summary>
    public string AssetNumber { get; set; } = string.Empty;

    /// <summary>
    /// Name/description of the asset.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Detailed description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Serial number.
    /// </summary>
    public string? SerialNumber { get; set; }

    /// <summary>
    /// Model number.
    /// </summary>
    public string? ModelNumber { get; set; }

    /// <summary>
    /// Manufacturer.
    /// </summary>
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Location within the site.
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Department or cost center responsible.
    /// </summary>
    public Guid? CostCenterId { get; set; }

    /// <summary>
    /// Date the asset was acquired.
    /// </summary>
    public DateTime AcquisitionDate { get; set; }

    /// <summary>
    /// Date the asset was placed in service.
    /// </summary>
    public DateTime? InServiceDate { get; set; }

    /// <summary>
    /// Original acquisition cost.
    /// </summary>
    public decimal AcquisitionCost { get; set; }

    /// <summary>
    /// Current book value (cost - accumulated depreciation).
    /// </summary>
    public decimal BookValue { get; set; }

    /// <summary>
    /// Salvage/residual value.
    /// </summary>
    public decimal SalvageValue { get; set; }

    /// <summary>
    /// Accumulated depreciation.
    /// </summary>
    public decimal AccumulatedDepreciation { get; set; }

    /// <summary>
    /// Useful life in months.
    /// </summary>
    public int UsefulLifeMonths { get; set; }

    /// <summary>
    /// Remaining useful life in months.
    /// </summary>
    public int RemainingLifeMonths { get; set; }

    /// <summary>
    /// Depreciation method ID.
    /// </summary>
    public Guid DepreciationMethodId { get; set; }

    /// <summary>
    /// Monthly depreciation amount.
    /// </summary>
    public decimal MonthlyDepreciation { get; set; }

    /// <summary>
    /// Status of the asset.
    /// </summary>
    public AssetStatus Status { get; set; } = AssetStatus.Active;

    /// <summary>
    /// Currency ID.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// Vendor the asset was purchased from.
    /// </summary>
    public Guid? VendorId { get; set; }

    /// <summary>
    /// Purchase order number.
    /// </summary>
    public string? PurchaseOrderNumber { get; set; }

    /// <summary>
    /// Invoice number.
    /// </summary>
    public string? InvoiceNumber { get; set; }

    /// <summary>
    /// Warranty expiration date.
    /// </summary>
    public DateTime? WarrantyExpirationDate { get; set; }

    /// <summary>
    /// Insured value.
    /// </summary>
    public decimal? InsuredValue { get; set; }

    /// <summary>
    /// Insurance policy number.
    /// </summary>
    public string? InsurancePolicyNumber { get; set; }

    /// <summary>
    /// Date of last physical inventory.
    /// </summary>
    public DateTime? LastInventoryDate { get; set; }

    /// <summary>
    /// Disposal date if disposed.
    /// </summary>
    public DateTime? DisposalDate { get; set; }

    /// <summary>
    /// Notes about the asset.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Site? Site { get; set; }
    public virtual AssetCategory AssetCategory { get; set; } = null!;
    public virtual DepreciationMethod DepreciationMethod { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
    public virtual ICollection<AssetDepreciation> DepreciationHistory { get; set; } = [];
    public virtual ICollection<AssetDisposal> Disposals { get; set; } = [];
}

/// <summary>
/// Status of a fixed asset.
/// </summary>
public enum AssetStatus
{
    /// <summary>
    /// Asset is in use and being depreciated.
    /// </summary>
    Active = 0,

    /// <summary>
    /// Asset is fully depreciated but still in use.
    /// </summary>
    FullyDepreciated = 1,

    /// <summary>
    /// Asset is temporarily not in use.
    /// </summary>
    Inactive = 2,

    /// <summary>
    /// Asset is being transferred to another location.
    /// </summary>
    InTransfer = 3,

    /// <summary>
    /// Asset has been disposed of.
    /// </summary>
    Disposed = 4,

    /// <summary>
    /// Asset has been sold.
    /// </summary>
    Sold = 5,

    /// <summary>
    /// Asset has been written off.
    /// </summary>
    WrittenOff = 6,

    /// <summary>
    /// Asset is pending disposal.
    /// </summary>
    PendingDisposal = 7
}
