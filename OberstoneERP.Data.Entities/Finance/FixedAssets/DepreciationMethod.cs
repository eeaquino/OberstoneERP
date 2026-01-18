namespace OberstoneERP.Data.Entities.Finance.FixedAssets;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a depreciation method for fixed assets.
/// </summary>
public class DepreciationMethod : BaseEntity
{
    /// <summary>
    /// Unique code for the depreciation method.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the depreciation method.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the method.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Type of depreciation calculation.
    /// </summary>
    public DepreciationType DepreciationType { get; set; }

    /// <summary>
    /// Indicates whether the method is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual ICollection<AssetCategory> AssetCategories { get; set; } = [];
}

/// <summary>
/// Types of depreciation calculation methods.
/// </summary>
public enum DepreciationType
{
    /// <summary>
    /// Equal depreciation each period over useful life.
    /// </summary>
    StraightLine = 0,

    /// <summary>
    /// Double declining balance method.
    /// </summary>
    DoubleDecliningBalance = 1,

    /// <summary>
    /// Sum of years digits method.
    /// </summary>
    SumOfYearsDigits = 2,

    /// <summary>
    /// Units of production method.
    /// </summary>
    UnitsOfProduction = 3,

    /// <summary>
    /// 150% declining balance method.
    /// </summary>
    DecliningBalance150 = 4,

    /// <summary>
    /// MACRS (Modified Accelerated Cost Recovery System).
    /// </summary>
    MACRS = 5,

    /// <summary>
    /// No depreciation.
    /// </summary>
    None = 99
}
