namespace OberstoneERP.Data.Entities.Finance.Controlling;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a profit center for profitability analysis.
/// </summary>
public class ProfitCenter : BaseEntity
{
    /// <summary>
    /// Company this profit center belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Site this profit center is associated with.
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Parent profit center ID for hierarchical structure.
    /// </summary>
    public Guid? ParentProfitCenterId { get; set; }

    /// <summary>
    /// Unique code for the profit center.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the profit center.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the profit center.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Hierarchical level (0 = root level).
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// Full hierarchical path.
    /// </summary>
    public string? HierarchyPath { get; set; }

    /// <summary>
    /// Manager responsible for this profit center.
    /// </summary>
    public Guid? ManagerId { get; set; }

    /// <summary>
    /// Date the profit center became active.
    /// </summary>
    public DateTime? ValidFrom { get; set; }

    /// <summary>
    /// Date the profit center became inactive.
    /// </summary>
    public DateTime? ValidTo { get; set; }

    /// <summary>
    /// Revenue target for the profit center.
    /// </summary>
    public decimal RevenueTarget { get; set; }

    /// <summary>
    /// Actual revenue for the profit center.
    /// </summary>
    public decimal ActualRevenue { get; set; }

    /// <summary>
    /// Cost target for the profit center.
    /// </summary>
    public decimal CostTarget { get; set; }

    /// <summary>
    /// Actual costs for the profit center.
    /// </summary>
    public decimal ActualCost { get; set; }

    /// <summary>
    /// Calculated profit (revenue - costs).
    /// </summary>
    public decimal Profit => ActualRevenue - ActualCost;

    /// <summary>
    /// Indicates whether the profit center is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Indicates if posting is allowed to this profit center.
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
    public virtual ProfitCenter? ParentProfitCenter { get; set; }
    public virtual ICollection<ProfitCenter> ChildProfitCenters { get; set; } = [];
}
