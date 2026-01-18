namespace OberstoneERP.Data.Entities.Finance.AccountsReceivable;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a customer invoice (accounts receivable document).
/// </summary>
public class CustomerInvoice : BaseEntity
{
    /// <summary>
    /// Company this invoice belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Site associated with this invoice.
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Customer ID.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Unique invoice number.
    /// </summary>
    public string InvoiceNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of the invoice.
    /// </summary>
    public DateTime InvoiceDate { get; set; }

    /// <summary>
    /// Due date for payment.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Payment terms ID used for this invoice.
    /// </summary>
    public Guid? PaymentTermsId { get; set; }

    /// <summary>
    /// Purchase order number from customer.
    /// </summary>
    public string? CustomerPurchaseOrder { get; set; }

    /// <summary>
    /// Reference or description.
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// Currency ID for the invoice.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// Exchange rate to functional currency.
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// Subtotal before tax.
    /// </summary>
    public decimal Subtotal { get; set; }

    /// <summary>
    /// Total discount amount.
    /// </summary>
    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// Total tax amount.
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// Total invoice amount.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Amount paid so far.
    /// </summary>
    public decimal PaidAmount { get; set; }

    /// <summary>
    /// Outstanding balance.
    /// </summary>
    public decimal BalanceDue => TotalAmount - PaidAmount;

    /// <summary>
    /// Amount in functional currency.
    /// </summary>
    public decimal FunctionalAmount { get; set; }

    /// <summary>
    /// Status of the invoice.
    /// </summary>
    public CustomerInvoiceStatus Status { get; set; } = CustomerInvoiceStatus.Draft;

    /// <summary>
    /// Date the invoice was posted.
    /// </summary>
    public DateTime? PostedDate { get; set; }

    /// <summary>
    /// Associated journal entry ID.
    /// </summary>
    public Guid? JournalEntryId { get; set; }

    // Billing Address
    public string? BillingAddressLine1 { get; set; }
    public string? BillingAddressLine2 { get; set; }
    public string? BillingCity { get; set; }
    public string? BillingStateProvince { get; set; }
    public string? BillingPostalCode { get; set; }
    public string? BillingCountryCode { get; set; }

    // Shipping Address
    public string? ShippingAddressLine1 { get; set; }
    public string? ShippingAddressLine2 { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingStateProvince { get; set; }
    public string? ShippingPostalCode { get; set; }
    public string? ShippingCountryCode { get; set; }

    /// <summary>
    /// Notes or comments.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Internal notes (not visible to customer).
    /// </summary>
    public string? InternalNotes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Site? Site { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
    public virtual PaymentTerms? PaymentTerms { get; set; }
    public virtual ICollection<CustomerInvoiceLine> Lines { get; set; } = [];
    public virtual ICollection<CustomerPaymentAllocation> PaymentAllocations { get; set; } = [];
}

/// <summary>
/// Status of a customer invoice.
/// </summary>
public enum CustomerInvoiceStatus
{
    Draft = 0,
    PendingApproval = 1,
    Approved = 2,
    Posted = 3,
    PartiallyPaid = 4,
    Paid = 5,
    Overdue = 6,
    Void = 7,
    WrittenOff = 8
}
