namespace OberstoneERP.Data.Entities.Finance.Intercompany;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents an intercompany transaction between two companies within the same tenant.
/// </summary>
public class IntercompanyTransaction : BaseEntity
{
    /// <summary>
    /// Intercompany agreement this transaction is under.
    /// </summary>
    public Guid? IntercompanyAgreementId { get; set; }

    /// <summary>
    /// Source company ID (seller/provider).
    /// </summary>
    public Guid SourceCompanyId { get; set; }

    /// <summary>
    /// Target company ID (buyer/receiver).
    /// </summary>
    public Guid TargetCompanyId { get; set; }

    /// <summary>
    /// Unique transaction number.
    /// </summary>
    public string TransactionNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of the transaction.
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// Type of intercompany transaction.
    /// </summary>
    public IntercompanyTransactionType TransactionType { get; set; }

    /// <summary>
    /// Description of the transaction.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Reference to source document.
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// Currency ID.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// Amount of the transaction.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Exchange rate to functional currency.
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// Amount in source company's functional currency.
    /// </summary>
    public decimal SourceFunctionalAmount { get; set; }

    /// <summary>
    /// Amount in target company's functional currency.
    /// </summary>
    public decimal TargetFunctionalAmount { get; set; }

    /// <summary>
    /// Status of the transaction.
    /// </summary>
    public IntercompanyTransactionStatus Status { get; set; } = IntercompanyTransactionStatus.Draft;

    /// <summary>
    /// Journal entry ID in source company.
    /// </summary>
    public Guid? SourceJournalEntryId { get; set; }

    /// <summary>
    /// Journal entry ID in target company.
    /// </summary>
    public Guid? TargetJournalEntryId { get; set; }

    /// <summary>
    /// Fiscal period ID in source company.
    /// </summary>
    public Guid SourceFiscalPeriodId { get; set; }

    /// <summary>
    /// Fiscal period ID in target company.
    /// </summary>
    public Guid TargetFiscalPeriodId { get; set; }

    /// <summary>
    /// Indicates if elimination entry has been created.
    /// </summary>
    public bool IsEliminated { get; set; }

    /// <summary>
    /// Elimination journal entry ID (for consolidated reporting).
    /// </summary>
    public Guid? EliminationJournalEntryId { get; set; }

    /// <summary>
    /// Matching transaction ID in counterparty company.
    /// </summary>
    public Guid? MatchingTransactionId { get; set; }

    /// <summary>
    /// Matching status with counterparty.
    /// </summary>
    public IntercompanyMatchingStatus MatchingStatus { get; set; } = IntercompanyMatchingStatus.Unmatched;

    /// <summary>
    /// User who approved the transaction in source company.
    /// </summary>
    public Guid? SourceApprovedBy { get; set; }

    /// <summary>
    /// Date approved in source company.
    /// </summary>
    public DateTime? SourceApprovedAt { get; set; }

    /// <summary>
    /// User who approved the transaction in target company.
    /// </summary>
    public Guid? TargetApprovedBy { get; set; }

    /// <summary>
    /// Date approved in target company.
    /// </summary>
    public DateTime? TargetApprovedAt { get; set; }

    /// <summary>
    /// Notes about the transaction.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual IntercompanyAgreement? IntercompanyAgreement { get; set; }
    public virtual Company SourceCompany { get; set; } = null!;
    public virtual Company TargetCompany { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
    public virtual FiscalPeriod SourceFiscalPeriod { get; set; } = null!;
    public virtual FiscalPeriod TargetFiscalPeriod { get; set; } = null!;
    public virtual IntercompanyTransaction? MatchingTransaction { get; set; }
    public virtual ICollection<IntercompanyTransactionLine> Lines { get; set; } = [];
}

/// <summary>
/// Types of intercompany transactions.
/// </summary>
public enum IntercompanyTransactionType
{
    /// <summary>
    /// Invoice from source to target.
    /// </summary>
    Invoice = 0,

    /// <summary>
    /// Credit note from source to target.
    /// </summary>
    CreditNote = 1,

    /// <summary>
    /// Payment from target to source.
    /// </summary>
    Payment = 2,

    /// <summary>
    /// Cost allocation/charge.
    /// </summary>
    CostAllocation = 3,

    /// <summary>
    /// Loan advance.
    /// </summary>
    LoanAdvance = 4,

    /// <summary>
    /// Loan repayment.
    /// </summary>
    LoanRepayment = 5,

    /// <summary>
    /// Interest charge.
    /// </summary>
    Interest = 6,

    /// <summary>
    /// Dividend/distribution.
    /// </summary>
    Dividend = 7,

    /// <summary>
    /// Capital contribution.
    /// </summary>
    CapitalContribution = 8,

    /// <summary>
    /// Other transaction type.
    /// </summary>
    Other = 99
}

/// <summary>
/// Status of an intercompany transaction.
/// </summary>
public enum IntercompanyTransactionStatus
{
    Draft = 0,
    PendingSourceApproval = 1,
    PendingTargetApproval = 2,
    Approved = 3,
    Posted = 4,
    PartiallySettled = 5,
    Settled = 6,
    Void = 7,
    Disputed = 8
}

/// <summary>
/// Matching status between intercompany counterparties.
/// </summary>
public enum IntercompanyMatchingStatus
{
    /// <summary>
    /// Not yet matched with counterparty.
    /// </summary>
    Unmatched = 0,

    /// <summary>
    /// Partially matched (amounts differ).
    /// </summary>
    PartialMatch = 1,

    /// <summary>
    /// Fully matched with counterparty.
    /// </summary>
    Matched = 2,

    /// <summary>
    /// Disputed - counterparty disagrees.
    /// </summary>
    Disputed = 3
}
