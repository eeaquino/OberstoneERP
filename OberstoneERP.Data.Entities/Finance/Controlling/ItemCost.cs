namespace OberstoneERP.Data.Entities.Finance.Controlling;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents the cost information for an item, supporting standard and average costing methods.
/// </summary>
public class ItemCost : BaseEntity
{
    /// <summary>
    /// Company this item cost belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Site this cost applies to (null = company-wide).
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Item/product code.
    /// </summary>
    public string ItemCode { get; set; } = string.Empty;

    /// <summary>
    /// Item description (denormalized for reporting).
    /// </summary>
    public string? ItemDescription { get; set; }

    /// <summary>
    /// Costing method used for this item.
    /// </summary>
    public CostingMethod CostingMethod { get; set; }

    /// <summary>
    /// Currency ID for the costs.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// Current standard cost per unit.
    /// </summary>
    public decimal StandardCost { get; set; }

    /// <summary>
    /// Pending standard cost (for future effective date).
    /// </summary>
    public decimal? PendingStandardCost { get; set; }

    /// <summary>
    /// Effective date for pending standard cost.
    /// </summary>
    public DateTime? PendingStandardCostEffectiveDate { get; set; }

    /// <summary>
    /// Current average cost per unit.
    /// </summary>
    public decimal AverageCost { get; set; }

    /// <summary>
    /// Last purchase price per unit.
    /// </summary>
    public decimal LastPurchasePrice { get; set; }

    /// <summary>
    /// Date of last purchase.
    /// </summary>
    public DateTime? LastPurchaseDate { get; set; }

    /// <summary>
    /// Current quantity on hand (for average cost calculation).
    /// </summary>
    public decimal QuantityOnHand { get; set; }

    /// <summary>
    /// Total inventory value at current cost.
    /// </summary>
    public decimal TotalInventoryValue { get; set; }

    /// <summary>
    /// Standard material cost component.
    /// </summary>
    public decimal StandardMaterialCost { get; set; }

    /// <summary>
    /// Standard labor cost component.
    /// </summary>
    public decimal StandardLaborCost { get; set; }

    /// <summary>
    /// Standard overhead cost component.
    /// </summary>
    public decimal StandardOverheadCost { get; set; }

    /// <summary>
    /// Standard outside processing cost component.
    /// </summary>
    public decimal StandardOutsideProcessingCost { get; set; }

    /// <summary>
    /// Date the standard cost was last updated.
    /// </summary>
    public DateTime? StandardCostLastUpdated { get; set; }

    /// <summary>
    /// User who last updated the standard cost.
    /// </summary>
    public Guid? StandardCostUpdatedBy { get; set; }

    /// <summary>
    /// Date the average cost was last recalculated.
    /// </summary>
    public DateTime? AverageCostLastUpdated { get; set; }

    /// <summary>
    /// Indicates whether the item cost is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Site? Site { get; set; }
    public virtual Currency Currency { get; set; } = null!;
    public virtual ICollection<ItemCostHistory> CostHistory { get; set; } = [];
}
