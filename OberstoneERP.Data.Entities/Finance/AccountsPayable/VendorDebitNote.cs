namespace OberstoneERP.Data.Entities.Finance.AccountsPayable;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a debit note issued to a vendor (reduces AP balance).
/// </summary>
public class VendorDebitNote : BaseEntity
{
    /// <summary>
    /// Company this debit note belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Site associated with this debit note.
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Vendor ID.
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// Original invoice ID if this debit note is related to a specific invoice.
    /// </summary>
    public Guid? OriginalInvoiceId { get; set; }

    /// <summary>
    /// Unique debit note number.
    /// </summary>
    public string DebitNoteNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of the debit note.
    /// </summary>
    public DateTime DebitNoteDate { get; set; }

    /// <summary>
    /// Reason for issuing the debit note.
    /// </summary>
    public DebitNoteReason Reason { get; set; }

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
    /// Total debit note amount.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Amount applied to invoices.
    /// </summary>
    public decimal AppliedAmount { get; set; }

    /// <summary>
    /// Remaining debit balance.
    /// </summary>
    public decimal RemainingDebit => TotalAmount - AppliedAmount;

    /// <summary>
    /// Amount in functional currency.
    /// </summary>
    public decimal FunctionalAmount { get; set; }

    /// <summary>
    /// Status of the debit note.
    /// </summary>
    public VendorDebitNoteStatus Status { get; set; } = VendorDebitNoteStatus.Draft;

    /// <summary>
    /// Date the debit note was posted.
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
    public virtual Vendor Vendor { get; set; } = null!;
    public virtual VendorInvoice? OriginalInvoice { get; set; }
    public virtual Currency Currency { get; set; } = null!;
    public virtual ICollection<VendorDebitNoteLine> Lines { get; set; } = [];
}

/// <summary>
/// Reasons for issuing a debit note.
/// </summary>
public enum DebitNoteReason
{
    Return = 0,
    Overcharge = 1,
    PricingError = 2,
    DamagedGoods = 3,
    ShortShipment = 4,
    QualityIssue = 5,
    Other = 99
}

/// <summary>
/// Status of a vendor debit note.
/// </summary>
public enum VendorDebitNoteStatus
{
    Draft = 0,
    PendingApproval = 1,
    Approved = 2,
    Posted = 3,
    PartiallyApplied = 4,
    FullyApplied = 5,
    Void = 6
}
