namespace OberstoneERP.Data.Entities.Finance.Controlling;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a cost element (type of cost) for management accounting.
/// </summary>
public class CostElement : BaseEntity
{
    /// <summary>
    /// Company this cost element belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Parent cost element ID for hierarchical structure.
    /// </summary>
    public Guid? ParentCostElementId { get; set; }

    /// <summary>
    /// Unique code for the cost element.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the cost element.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the cost element.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Category of cost element.
    /// </summary>
    public CostElementCategory Category { get; set; }

    /// <summary>
    /// Type of cost element.
    /// </summary>
    public CostElementType CostElementType { get; set; }

    /// <summary>
    /// Linked GL account ID if this is a primary cost element.
    /// </summary>
    public Guid? LinkedAccountId { get; set; }

    /// <summary>
    /// Hierarchical level (0 = root level).
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// Full hierarchical path.
    /// </summary>
    public string? HierarchyPath { get; set; }

    /// <summary>
    /// Date the cost element became active.
    /// </summary>
    public DateTime? ValidFrom { get; set; }

    /// <summary>
    /// Date the cost element became inactive.
    /// </summary>
    public DateTime? ValidTo { get; set; }

    /// <summary>
    /// Indicates whether the cost element is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Sort order for display purposes.
    /// </summary>
    public int SortOrder { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual CostElement? ParentCostElement { get; set; }
    public virtual ICollection<CostElement> ChildCostElements { get; set; } = [];
}

/// <summary>
/// Categories of cost elements.
/// </summary>
public enum CostElementCategory
{
    /// <summary>
    /// Primary costs from external sources.
    /// </summary>
    Primary = 0,

    /// <summary>
    /// Secondary costs from internal allocations.
    /// </summary>
    Secondary = 1,

    /// <summary>
    /// Revenue elements.
    /// </summary>
    Revenue = 2
}

/// <summary>
/// Types of cost elements.
/// </summary>
public enum CostElementType
{
    /// <summary>
    /// Material costs.
    /// </summary>
    Material = 0,

    /// <summary>
    /// Labor/personnel costs.
    /// </summary>
    Labor = 1,

    /// <summary>
    /// External service costs.
    /// </summary>
    ExternalService = 2,

    /// <summary>
    /// Depreciation costs.
    /// </summary>
    Depreciation = 3,

    /// <summary>
    /// Interest costs.
    /// </summary>
    Interest = 4,

    /// <summary>
    /// Internal activity allocation.
    /// </summary>
    InternalActivity = 5,

        /// <summary>
        /// Assessment/distribution.
        /// </summary>
        Assessment = 6,

        /// <summary>
        /// Settlement costs.
        /// </summary>
        Settlement = 7,

        /// <summary>
        /// Purchase price variance (standard costing).
        /// </summary>
        PurchasePriceVariance = 8,

        /// <summary>
        /// Material usage/quantity variance (standard costing).
        /// </summary>
        MaterialUsageVariance = 9,

        /// <summary>
        /// Labor rate variance (standard costing).
        /// </summary>
        LaborRateVariance = 10,

        /// <summary>
        /// Labor efficiency variance (standard costing).
        /// </summary>
        LaborEfficiencyVariance = 11,

        /// <summary>
        /// Overhead variance (standard costing).
        /// </summary>
        OverheadVariance = 12,

        /// <summary>
        /// Inventory revaluation adjustment.
        /// </summary>
        InventoryRevaluation = 13,

        /// <summary>
        /// Other costs.
        /// </summary>
        Other = 99
    }
