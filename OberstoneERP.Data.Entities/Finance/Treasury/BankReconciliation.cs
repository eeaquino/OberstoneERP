namespace OberstoneERP.Data.Entities.Finance.Treasury;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a bank reconciliation session.
/// </summary>
public class BankReconciliation : BaseEntity
{
    /// <summary>
    /// Company this reconciliation belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Bank account being reconciled.
    /// </summary>
    public Guid BankAccountId { get; set; }

    /// <summary>
    /// Statement date being reconciled.
    /// </summary>
    public DateTime StatementDate { get; set; }

    /// <summary>
    /// Statement number/reference.
    /// </summary>
    public string? StatementNumber { get; set; }

    /// <summary>
    /// Beginning balance per bank statement.
    /// </summary>
    public decimal StatementBeginningBalance { get; set; }

    /// <summary>
    /// Ending balance per bank statement.
    /// </summary>
    public decimal StatementEndingBalance { get; set; }

    /// <summary>
    /// Book balance at start of reconciliation period.
    /// </summary>
    public decimal BookBeginningBalance { get; set; }

    /// <summary>
    /// Book balance at end of reconciliation period.
    /// </summary>
    public decimal BookEndingBalance { get; set; }

    /// <summary>
    /// Total deposits cleared during reconciliation.
    /// </summary>
    public decimal ClearedDeposits { get; set; }

    /// <summary>
    /// Total withdrawals cleared during reconciliation.
    /// </summary>
    public decimal ClearedWithdrawals { get; set; }

    /// <summary>
    /// Total deposits in transit (not yet on statement).
    /// </summary>
    public decimal DepositsInTransit { get; set; }

    /// <summary>
    /// Total outstanding checks (not yet cleared).
    /// </summary>
    public decimal OutstandingChecks { get; set; }

    /// <summary>
    /// Calculated difference (should be zero when reconciled).
    /// </summary>
    public decimal Difference { get; set; }

    /// <summary>
    /// Status of the reconciliation.
    /// </summary>
    public ReconciliationStatus Status { get; set; } = ReconciliationStatus.InProgress;

    /// <summary>
    /// Date the reconciliation was completed.
    /// </summary>
    public DateTime? CompletedDate { get; set; }

    /// <summary>
    /// User who completed the reconciliation.
    /// </summary>
    public Guid? CompletedBy { get; set; }

    /// <summary>
    /// Notes about the reconciliation.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual BankAccount BankAccount { get; set; } = null!;
    public virtual ICollection<BankTransaction> ReconciledTransactions { get; set; } = [];
}

/// <summary>
/// Status of a bank reconciliation.
/// </summary>
public enum ReconciliationStatus
{
    InProgress = 0,
    Balanced = 1,
    Completed = 2,
    Void = 3
}
