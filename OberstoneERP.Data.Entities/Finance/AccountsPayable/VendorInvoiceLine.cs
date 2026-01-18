namespace OberstoneERP.Data.Entities.Finance.AccountsPayable;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents a line item on a vendor invoice.
/// </summary>
public class VendorInvoiceLine : BaseEntity
{
    /// <summary>
    /// Invoice this line belongs to.
    /// </summary>
    public Guid VendorInvoiceId { get; set; }

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
    /// Expense/Asset account ID.
    /// </summary>
    public Guid AccountId { get; set; }

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
    /// Internal order ID for project tracking.
    /// </summary>
    public Guid? InternalOrderId { get; set; }

    /// <summary>
    /// Asset ID if this is a fixed asset purchase.
    /// </summary>
    public Guid? AssetId { get; set; }

        /// <summary>
        /// Indicates if this line is billable to a customer.
        /// </summary>
        public bool IsBillable { get; set; }

        /// <summary>
        /// Customer ID if billable.
        /// </summary>
        public Guid? BillableCustomerId { get; set; }

        /// <summary>
        /// Standard cost per unit (if using standard costing).
        /// </summary>
        public decimal StandardUnitCost { get; set; }

        /// <summary>
        /// Purchase price variance (actual price - standard cost) * quantity.
        /// </summary>
        public decimal PurchasePriceVariance { get; set; }

        /// <summary>
        /// Indicates if this line updates item costs.
        /// </summary>
        public bool UpdateItemCost { get; set; } = true;

        /// <summary>
        /// Variance account ID for posting price variances.
        /// </summary>
        public Guid? VarianceAccountId { get; set; }

        // Navigation properties
        public virtual Tenant Tenant { get; set; } = null!;
        public virtual VendorInvoice VendorInvoice { get; set; } = null!;
        public virtual Account Account { get; set; } = null!;
        public virtual Account? VarianceAccount { get; set; }
    }
