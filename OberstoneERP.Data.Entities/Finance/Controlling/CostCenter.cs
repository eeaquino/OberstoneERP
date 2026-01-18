namespace OberstoneERP.Data.Entities.Finance.Controlling;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a cost center for cost allocation and management accounting.
/// </summary>
public class CostCenter : BaseEntity
{
    /// <summary>
    /// Company this cost center belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Site this cost center is associated with.
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Parent cost center ID for hierarchical structure.
    /// </summary>
    public Guid? ParentCostCenterId { get; set; }

    /// <summary>
    /// Unique code for the cost center.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the cost center.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the cost center.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Type of cost center.
    /// </summary>
    public CostCenterType CostCenterType { get; set; }

    /// <summary>
    /// Hierarchical level (0 = root level).
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// Full hierarchical path.
    /// </summary>
    public string? HierarchyPath { get; set; }

    /// <summary>
    /// Manager responsible for this cost center.
    /// </summary>
    public Guid? ManagerId { get; set; }

    /// <summary>
    /// Date the cost center became active.
    /// </summary>
    public DateTime? ValidFrom { get; set; }

    /// <summary>
    /// Date the cost center became inactive.
    /// </summary>
    public DateTime? ValidTo { get; set; }

    /// <summary>
    /// Budget amount for the cost center.
    /// </summary>
    public decimal BudgetAmount { get; set; }

    /// <summary>
    /// Actual costs allocated to this cost center.
    /// </summary>
    public decimal ActualAmount { get; set; }

    /// <summary>
    /// Indicates whether the cost center is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Indicates if posting is allowed to this cost center.
    /// </summary>
    public bool AllowPosting { get; set; } = true;

    /// <summary>
    /// Sort order for display purposes.
    /// </summary>
    public int SortOrder { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Site? Site { get; set; }
    public virtual CostCenter? ParentCostCenter { get; set; }
    public virtual ICollection<CostCenter> ChildCostCenters { get; set; } = [];
}

/// <summary>
/// Types of cost centers.
/// </summary>
public enum CostCenterType
{
    /// <summary>
    /// Organizational cost center (department, division).
    /// </summary>
    Organizational = 0,

    /// <summary>
    /// Production cost center.
    /// </summary>
    Production = 1,

    /// <summary>
    /// Service cost center.
    /// </summary>
    Service = 2,

    /// <summary>
    /// Administrative cost center.
    /// </summary>
    Administrative = 3,

    /// <summary>
    /// Sales/Distribution cost center.
    /// </summary>
    Distribution = 4,

    /// <summary>
    /// Research and Development cost center.
    /// </summary>
    Research = 5,

    /// <summary>
    /// Supporting cost center for allocation.
    /// </summary>
    Support = 6
}
