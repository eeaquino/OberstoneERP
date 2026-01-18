namespace OberstoneERP.Data.Entities.Finance.Treasury;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a bank transaction (deposit, withdrawal, transfer, etc.).
/// </summary>
public class BankTransaction : BaseEntity
{
    /// <summary>
    /// Company this transaction belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Bank account ID.
    /// </summary>
    public Guid BankAccountId { get; set; }

    /// <summary>
    /// Unique transaction number.
    /// </summary>
    public string TransactionNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of the transaction.
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// Value/clearing date.
    /// </summary>
    public DateTime? ValueDate { get; set; }

    /// <summary>
    /// Type of bank transaction.
    /// </summary>
    public BankTransactionType TransactionType { get; set; }

    /// <summary>
    /// Reference number (check number, wire reference, etc.).
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// Description of the transaction.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Payee/payer name.
    /// </summary>
    public string? PayeePayer { get; set; }

    /// <summary>
    /// Deposit amount (positive for deposits).
    /// </summary>
    public decimal DepositAmount { get; set; }

    /// <summary>
    /// Withdrawal amount (positive for withdrawals).
    /// </summary>
    public decimal WithdrawalAmount { get; set; }

    /// <summary>
    /// Net amount (positive = deposit, negative = withdrawal).
    /// </summary>
    public decimal NetAmount => DepositAmount - WithdrawalAmount;

    /// <summary>
    /// Running balance after this transaction.
    /// </summary>
    public decimal RunningBalance { get; set; }

    /// <summary>
    /// Status of the transaction.
    /// </summary>
    public BankTransactionStatus Status { get; set; } = BankTransactionStatus.Unreconciled;

    /// <summary>
    /// Bank statement ID if imported from statement.
    /// </summary>
    public Guid? BankStatementId { get; set; }

    /// <summary>
    /// Bank statement line number.
    /// </summary>
    public int? StatementLineNumber { get; set; }

    /// <summary>
    /// Bank reconciliation ID when reconciled.
    /// </summary>
    public Guid? BankReconciliationId { get; set; }

    /// <summary>
    /// Source document type that created this transaction.
    /// </summary>
    public BankSourceDocumentType? SourceDocumentType { get; set; }

    /// <summary>
    /// Source document ID.
    /// </summary>
    public Guid? SourceDocumentId { get; set; }

    /// <summary>
    /// Associated journal entry ID.
    /// </summary>
    public Guid? JournalEntryId { get; set; }

    /// <summary>
    /// Notes about the transaction.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual BankAccount BankAccount { get; set; } = null!;
    public virtual BankReconciliation? BankReconciliation { get; set; }
}

/// <summary>
/// Types of bank transactions.
/// </summary>
public enum BankTransactionType
{
    Deposit = 0,
    Withdrawal = 1,
    Check = 2,
    Transfer = 3,
    WireTransfer = 4,
    ACH = 5,
    DirectDebit = 6,
    Fee = 7,
    Interest = 8,
    Adjustment = 9,
    Other = 99
}

/// <summary>
/// Status of a bank transaction.
/// </summary>
public enum BankTransactionStatus
{
    /// <summary>
    /// Transaction has not been reconciled with bank statement.
    /// </summary>
    Unreconciled = 0,

    /// <summary>
    /// Transaction is pending (e.g., check not yet cleared).
    /// </summary>
    Pending = 1,

    /// <summary>
    /// Transaction has been reconciled.
    /// </summary>
    Reconciled = 2,

    /// <summary>
    /// Transaction has been voided.
    /// </summary>
    Void = 3
}

/// <summary>
/// Source document types for bank transactions.
/// </summary>
public enum BankSourceDocumentType
{
    CustomerPayment = 0,
    VendorPayment = 1,
    BankDeposit = 2,
    BankTransfer = 3,
    Manual = 4
}
