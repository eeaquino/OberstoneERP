namespace OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a general ledger account in the chart of accounts.
/// </summary>
public class Account : BaseEntity
{
    /// <summary>
    /// Company this account belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Account type ID.
    /// </summary>
    public Guid AccountTypeId { get; set; }

    /// <summary>
    /// Account group ID for organizational hierarchy.
    /// </summary>
    public Guid? AccountGroupId { get; set; }

    /// <summary>
    /// Unique account number/code within the company.
    /// </summary>
    public string AccountNumber { get; set; } = string.Empty;

    /// <summary>
    /// Name of the account.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the account.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Currency ID for the account (if currency-specific).
    /// </summary>
    public Guid? CurrencyId { get; set; }

    /// <summary>
    /// Indicates if posting is allowed to this account.
    /// </summary>
    public bool IsPostingAllowed { get; set; } = true;

    /// <summary>
    /// Indicates if this is a control/reconciliation account (e.g., AR, AP control).
    /// </summary>
    public bool IsControlAccount { get; set; }

    /// <summary>
    /// Type of control account if applicable.
    /// </summary>
    public ControlAccountType? ControlAccountType { get; set; }

    /// <summary>
    /// Indicates if the account requires cost center assignment.
    /// </summary>
    public bool RequiresCostCenter { get; set; }

    /// <summary>
    /// Indicates if the account requires profit center assignment.
    /// </summary>
    public bool RequiresProfitCenter { get; set; }

    /// <summary>
    /// Indicates if the account is a bank account.
    /// </summary>
    public bool IsBankAccount { get; set; }

    /// <summary>
    /// Indicates if the account is used for cash.
    /// </summary>
    public bool IsCashAccount { get; set; }

    /// <summary>
    /// Current balance of the account.
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// Indicates whether the account is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Date the account was opened.
    /// </summary>
    public DateTime? OpenedDate { get; set; }

    /// <summary>
    /// Date the account was closed.
    /// </summary>
    public DateTime? ClosedDate { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual AccountType AccountType { get; set; } = null!;
    public virtual AccountGroup? AccountGroup { get; set; }
    public virtual Currency? Currency { get; set; }
    public virtual ICollection<JournalEntryLine> JournalEntryLines { get; set; } = [];
}

/// <summary>
/// Types of control accounts.
/// </summary>
public enum ControlAccountType
{
    AccountsReceivable = 1,
    AccountsPayable = 2,
    Inventory = 3,
    FixedAssets = 4,
    AccumulatedDepreciation = 5,
    Bank = 6
}
