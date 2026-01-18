namespace OberstoneERP.Data.Entities.Finance.AccountsReceivable;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents the allocation of a payment to one or more invoices.
/// </summary>
public class CustomerPaymentAllocation : BaseEntity
{
    /// <summary>
    /// Payment this allocation belongs to.
    /// </summary>
    public Guid CustomerPaymentId { get; set; }

    /// <summary>
    /// Invoice being paid.
    /// </summary>
    public Guid CustomerInvoiceId { get; set; }

    /// <summary>
    /// Amount applied to this invoice.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Discount taken on this invoice.
    /// </summary>
    public decimal DiscountTaken { get; set; }

    /// <summary>
    /// Write-off amount for this invoice.
    /// </summary>
    public decimal WriteOffAmount { get; set; }

    /// <summary>
    /// Exchange gain/loss if currencies differ.
    /// </summary>
    public decimal ExchangeGainLoss { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual CustomerPayment CustomerPayment { get; set; } = null!;
    public virtual CustomerInvoice CustomerInvoice { get; set; } = null!;
}
