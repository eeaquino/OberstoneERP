namespace OberstoneERP.Data.Entities.Finance.AccountsReceivable;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents a line item on a customer invoice.
/// </summary>
public class CustomerInvoiceLine : BaseEntity
{
    /// <summary>
    /// Invoice this line belongs to.
    /// </summary>
    public Guid CustomerInvoiceId { get; set; }

    /// <summary>
    /// Line number within the invoice.
    /// </summary>
    public int LineNumber { get; set; }

    /// <summary>
    /// Item/product code (if applicable).
    /// </summary>
    public string? ItemCode { get; set; }

    /// <summary>
    /// Description of the line item.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Revenue account ID.
    /// </summary>
    public Guid RevenueAccountId { get; set; }

    /// <summary>
    /// Quantity.
    /// </summary>
    public decimal Quantity { get; set; } = 1;

    /// <summary>
    /// Unit of measure.
    /// </summary>
    public string? UnitOfMeasure { get; set; }

    /// <summary>
    /// Unit price.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Line discount percentage.
    /// </summary>
    public decimal DiscountPercent { get; set; }

    /// <summary>
    /// Line discount amount.
    /// </summary>
    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// Net amount (quantity * unit price - discount).
    /// </summary>
    public decimal NetAmount { get; set; }

    /// <summary>
    /// Tax code ID.
    /// </summary>
    public Guid? TaxCodeId { get; set; }

    /// <summary>
    /// Tax amount for this line.
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// Total line amount including tax.
    /// </summary>
    public decimal TotalAmount { get; set; }

        /// <summary>
        /// Cost center ID for allocation.
        /// </summary>
        public Guid? CostCenterId { get; set; }

        /// <summary>
        /// Profit center ID for allocation.
        /// </summary>
        public Guid? ProfitCenterId { get; set; }

        /// <summary>
        /// Unit cost at time of sale (for COGS calculation).
        /// </summary>
        public decimal UnitCost { get; set; }

        /// <summary>
        /// Total cost of goods sold for this line.
        /// </summary>
        public decimal CostOfGoodsSold { get; set; }

        /// <summary>
        /// Standard cost per unit (if using standard costing).
        /// </summary>
        public decimal StandardUnitCost { get; set; }

        /// <summary>
        /// Cost variance amount (actual cost - standard cost) * quantity.
        /// </summary>
        public decimal CostVariance { get; set; }

        /// <summary>
        /// COGS account ID.
        /// </summary>
        public Guid? CostOfGoodsSoldAccountId { get; set; }

        // Navigation properties
        public virtual Tenant Tenant { get; set; } = null!;
        public virtual CustomerInvoice CustomerInvoice { get; set; } = null!;
        public virtual Account RevenueAccount { get; set; } = null!;
        public virtual Account? CostOfGoodsSoldAccount { get; set; }
    }
