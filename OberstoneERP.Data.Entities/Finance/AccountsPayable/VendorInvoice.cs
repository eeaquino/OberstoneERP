namespace OberstoneERP.Data.Entities.Finance.AccountsPayable;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;

/// <summary>
/// Represents a vendor invoice (accounts payable document).
/// </summary>
public class VendorInvoice : BaseEntity
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
    /// Vendor ID.
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// Internal invoice number.
    /// </summary>
    public string InvoiceNumber { get; set; } = string.Empty;

    /// <summary>
    /// Vendor's invoice number.
    /// </summary>
    public string VendorInvoiceNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of the vendor's invoice.
    /// </summary>
    public DateTime InvoiceDate { get; set; }

    /// <summary>
    /// Date the invoice was received.
    /// </summary>
    public DateTime ReceivedDate { get; set; }

    /// <summary>
    /// Due date for payment.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Payment terms ID used for this invoice.
    /// </summary>
    public Guid? PaymentTermsId { get; set; }

    /// <summary>
    /// Our purchase order number.
    /// </summary>
    public string? PurchaseOrderNumber { get; set; }

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
    /// Total withholding tax amount.
    /// </summary>
    public decimal WithholdingTaxAmount { get; set; }

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
    public VendorInvoiceStatus Status { get; set; } = VendorInvoiceStatus.Draft;

    /// <summary>
    /// Invoice type.
    /// </summary>
    public VendorInvoiceType InvoiceType { get; set; } = VendorInvoiceType.Standard;

    /// <summary>
    /// Date the invoice was posted.
    /// </summary>
    public DateTime? PostedDate { get; set; }

    /// <summary>
    /// Associated journal entry ID.
    /// </summary>
    public Guid? JournalEntryId { get; set; }

    /// <summary>
    /// User who approved the invoice.
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// Date the invoice was approved.
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// Indicates if the invoice is on hold.
    /// </summary>
    public bool IsOnHold { get; set; }

    /// <summary>
    /// Reason for hold.
    /// </summary>
    public string? HoldReason { get; set; }

    /// <summary>
    /// Notes or comments.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Internal notes.
    /// </summary>
    public string? InternalNotes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Site? Site { get; set; }
    public virtual Vendor Vendor { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
    public virtual PaymentTerms? PaymentTerms { get; set; }
    public virtual ICollection<VendorInvoiceLine> Lines { get; set; } = [];
    public virtual ICollection<VendorPaymentAllocation> PaymentAllocations { get; set; } = [];
}

/// <summary>
/// Status of a vendor invoice.
/// </summary>
public enum VendorInvoiceStatus
{
    Draft = 0,
    PendingApproval = 1,
    Approved = 2,
    Posted = 3,
    PartiallyPaid = 4,
    Paid = 5,
    OnHold = 6,
    Void = 7,
    Disputed = 8
}

/// <summary>
/// Types of vendor invoices.
/// </summary>
public enum VendorInvoiceType
{
    Standard = 0,
    Prepayment = 1,
    Recurring = 2,
    CreditMemo = 3
}
