namespace OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a journal entry (general ledger posting).
/// </summary>
public class JournalEntry : BaseEntity
{
    /// <summary>
    /// Company this journal entry belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Site associated with this journal entry.
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Fiscal period this entry is posted to.
    /// </summary>
    public Guid FiscalPeriodId { get; set; }

    /// <summary>
    /// Unique journal entry number within the company.
    /// </summary>
    public string EntryNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of the journal entry.
    /// </summary>
    public DateTime EntryDate { get; set; }

    /// <summary>
    /// Date the entry was posted to the general ledger.
    /// </summary>
    public DateTime? PostingDate { get; set; }

    /// <summary>
    /// Description or memo for the journal entry.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Reference number (e.g., invoice number, check number).
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// Type of journal entry.
    /// </summary>
    public JournalEntryType EntryType { get; set; }

    /// <summary>
    /// Source document type that created this entry.
    /// </summary>
    public SourceDocumentType? SourceDocumentType { get; set; }

    /// <summary>
    /// Source document ID reference.
    /// </summary>
    public Guid? SourceDocumentId { get; set; }

    /// <summary>
    /// Status of the journal entry.
    /// </summary>
    public JournalEntryStatus Status { get; set; } = JournalEntryStatus.Draft;

    /// <summary>
    /// Total debit amount of all lines.
    /// </summary>
    public decimal TotalDebit { get; set; }

    /// <summary>
    /// Total credit amount of all lines.
    /// </summary>
    public decimal TotalCredit { get; set; }

    /// <summary>
    /// Currency ID for the journal entry.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// Exchange rate to the company's functional currency.
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// Indicates if this is a reversing entry.
    /// </summary>
    public bool IsReversing { get; set; }

    /// <summary>
    /// The original entry ID if this is a reversal.
    /// </summary>
    public Guid? ReversedEntryId { get; set; }

    /// <summary>
    /// Date the entry should auto-reverse.
    /// </summary>
    public DateTime? AutoReverseDate { get; set; }

    /// <summary>
    /// User who approved the entry.
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// Date the entry was approved.
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Site? Site { get; set; }
    public virtual FiscalPeriod FiscalPeriod { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
    public virtual JournalEntry? ReversedEntry { get; set; }
    public virtual ICollection<JournalEntryLine> Lines { get; set; } = [];
}

/// <summary>
/// Types of journal entries.
/// </summary>
public enum JournalEntryType
{
    Standard = 0,
    Adjustment = 1,
    Closing = 2,
    Opening = 3,
    Reversal = 4,
    Recurring = 5,
    Statistical = 6
}

/// <summary>
/// Source document types for journal entries.
/// </summary>
public enum SourceDocumentType
{
    Manual = 0,
    CustomerInvoice = 1,
    CustomerPayment = 2,
    CustomerCreditNote = 3,
    VendorInvoice = 4,
    VendorPayment = 5,
    VendorDebitNote = 6,
    BankTransaction = 7,
    AssetDepreciation = 8,
    AssetDisposal = 9,
    Intercompany = 10,
    Payroll = 11,
    Inventory = 12
}

/// <summary>
/// Status of a journal entry.
/// </summary>
public enum JournalEntryStatus
{
    Draft = 0,
    PendingApproval = 1,
    Approved = 2,
    Posted = 3,
    Reversed = 4,
    Rejected = 5
}
