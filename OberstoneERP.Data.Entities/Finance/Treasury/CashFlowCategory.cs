namespace OberstoneERP.Data.Entities.Finance.Treasury;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a category for cash flow classification.
/// </summary>
public class CashFlowCategory : BaseEntity
{
    /// <summary>
    /// Company this category belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Parent category ID for hierarchical structure.
    /// </summary>
    public Guid? ParentCategoryId { get; set; }

    /// <summary>
    /// Unique code for the category.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the category.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the category.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Type of cash flow activity.
    /// </summary>
    public CashFlowActivityType ActivityType { get; set; }

    /// <summary>
    /// Indicates if this is an inflow (positive) or outflow (negative) category.
    /// </summary>
    public CashFlowDirection Direction { get; set; }

    /// <summary>
    /// Hierarchical level (0 = root level).
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// Indicates whether the category is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Sort order for display purposes.
    /// </summary>
    public int SortOrder { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual CashFlowCategory? ParentCategory { get; set; }
    public virtual ICollection<CashFlowCategory> ChildCategories { get; set; } = [];
    public virtual ICollection<CashFlowForecast> Forecasts { get; set; } = [];
}

/// <summary>
/// Types of cash flow activities per GAAP/IFRS classification.
/// </summary>
public enum CashFlowActivityType
{
    /// <summary>
    /// Operating activities (day-to-day business).
    /// </summary>
    Operating = 0,

    /// <summary>
    /// Investing activities (assets, investments).
    /// </summary>
    Investing = 1,

    /// <summary>
    /// Financing activities (debt, equity).
    /// </summary>
    Financing = 2
}

/// <summary>
/// Direction of cash flow.
/// </summary>
public enum CashFlowDirection
{
    /// <summary>
    /// Cash inflow (receipts).
    /// </summary>
    Inflow = 0,

    /// <summary>
    /// Cash outflow (payments).
    /// </summary>
    Outflow = 1
}
