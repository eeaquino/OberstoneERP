namespace OberstoneERP.Data.Entities.Finance.AccountsReceivable;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a credit note issued to a customer (reduces AR balance).
/// </summary>
public class CustomerCreditNote : BaseEntity
{
    /// <summary>
    /// Company this credit note belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Site associated with this credit note.
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Customer ID.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Original invoice ID if this credit note is related to a specific invoice.
    /// </summary>
    public Guid? OriginalInvoiceId { get; set; }

    /// <summary>
    /// Unique credit note number.
    /// </summary>
    public string CreditNoteNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of the credit note.
    /// </summary>
    public DateTime CreditNoteDate { get; set; }

    /// <summary>
    /// Reason for issuing the credit note.
    /// </summary>
    public CreditNoteReason Reason { get; set; }

    /// <summary>
    /// Reference or description.
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// Currency ID.
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
    /// Total tax amount.
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// Total credit note amount.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Amount applied to invoices.
    /// </summary>
    public decimal AppliedAmount { get; set; }

    /// <summary>
    /// Remaining credit balance.
    /// </summary>
    public decimal RemainingCredit => TotalAmount - AppliedAmount;

    /// <summary>
    /// Amount in functional currency.
    /// </summary>
    public decimal FunctionalAmount { get; set; }

    /// <summary>
    /// Status of the credit note.
    /// </summary>
    public CustomerCreditNoteStatus Status { get; set; } = CustomerCreditNoteStatus.Draft;

    /// <summary>
    /// Date the credit note was posted.
    /// </summary>
    public DateTime? PostedDate { get; set; }

    /// <summary>
    /// Associated journal entry ID.
    /// </summary>
    public Guid? JournalEntryId { get; set; }

    /// <summary>
    /// Notes or comments.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Site? Site { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    public virtual CustomerInvoice? OriginalInvoice { get; set; }
    public virtual Currency Currency { get; set; } = null!;
    public virtual ICollection<CustomerCreditNoteLine> Lines { get; set; } = [];
}

/// <summary>
/// Reasons for issuing a credit note.
/// </summary>
public enum CreditNoteReason
{
    Return = 0,
    Discount = 1,
    PricingError = 2,
    DamagedGoods = 3,
    ShortShipment = 4,
    CustomerGoodwill = 5,
    Other = 99
}

/// <summary>
/// Status of a customer credit note.
/// </summary>
public enum CustomerCreditNoteStatus
{
    Draft = 0,
    PendingApproval = 1,
    Approved = 2,
    Posted = 3,
    PartiallyApplied = 4,
    FullyApplied = 5,
    Void = 6
}
