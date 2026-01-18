namespace OberstoneERP.Data.Entities.Finance.FixedAssets;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents a category or class of fixed assets.
/// </summary>
public class AssetCategory : BaseEntity
{
    /// <summary>
    /// Company this asset category belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Parent category ID for hierarchical structure.
    /// </summary>
    public Guid? ParentCategoryId { get; set; }

    /// <summary>
    /// Unique code for the asset category.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the asset category.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the category.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Default useful life in months.
    /// </summary>
    public int DefaultUsefulLifeMonths { get; set; }

    /// <summary>
    /// Default salvage value percentage.
    /// </summary>
    public decimal DefaultSalvageValuePercent { get; set; }

    /// <summary>
    /// Default depreciation method ID.
    /// </summary>
    public Guid? DefaultDepreciationMethodId { get; set; }

    /// <summary>
    /// Fixed asset account ID.
    /// </summary>
    public Guid AssetAccountId { get; set; }

    /// <summary>
    /// Accumulated depreciation account ID.
    /// </summary>
    public Guid AccumulatedDepreciationAccountId { get; set; }

    /// <summary>
    /// Depreciation expense account ID.
    /// </summary>
    public Guid DepreciationExpenseAccountId { get; set; }

    /// <summary>
    /// Gain on disposal account ID.
    /// </summary>
    public Guid? GainOnDisposalAccountId { get; set; }

    /// <summary>
    /// Loss on disposal account ID.
    /// </summary>
    public Guid? LossOnDisposalAccountId { get; set; }

    /// <summary>
    /// Indicates whether the category is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual AssetCategory? ParentCategory { get; set; }
    public virtual DepreciationMethod? DefaultDepreciationMethod { get; set; }
    public virtual Account AssetAccount { get; set; } = null!;
    public virtual Account AccumulatedDepreciationAccount { get; set; } = null!;
    public virtual Account DepreciationExpenseAccount { get; set; } = null!;
    public virtual ICollection<AssetCategory> ChildCategories { get; set; } = [];
    public virtual ICollection<Asset> Assets { get; set; } = [];
}
