namespace OberstoneERP.Data.Entities.Finance.AccountsPayable;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents the allocation of a payment to one or more invoices.
/// </summary>
public class VendorPaymentAllocation : BaseEntity
{
    /// <summary>
    /// Payment this allocation belongs to.
    /// </summary>
    public Guid VendorPaymentId { get; set; }

    /// <summary>
    /// Invoice being paid.
    /// </summary>
    public Guid VendorInvoiceId { get; set; }

    /// <summary>
    /// Amount applied to this invoice.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Discount taken on this invoice.
    /// </summary>
    public decimal DiscountTaken { get; set; }

    /// <summary>
    /// Withholding tax deducted.
    /// </summary>
    public decimal WithholdingTax { get; set; }

    /// <summary>
    /// Exchange gain/loss if currencies differ.
    /// </summary>
    public decimal ExchangeGainLoss { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual VendorPayment VendorPayment { get; set; } = null!;
    public virtual VendorInvoice VendorInvoice { get; set; } = null!;
}
