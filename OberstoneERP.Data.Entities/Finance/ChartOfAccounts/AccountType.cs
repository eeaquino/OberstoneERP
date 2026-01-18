namespace OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a classification type for general ledger accounts.
/// </summary>
public class AccountType : BaseEntity
{
    /// <summary>
    /// Unique code for the account type within the tenant.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the account type.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the account type.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The balance sheet category this account type belongs to.
    /// </summary>
    public AccountCategory Category { get; set; }

    /// <summary>
    /// Normal balance side for this account type.
    /// </summary>
    public BalanceSide NormalBalance { get; set; }

    /// <summary>
    /// Indicates whether the account type is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Sort order for display purposes.
    /// </summary>
    public int SortOrder { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual ICollection<Account> Accounts { get; set; } = [];
}

/// <summary>
/// Major categories of accounts in the chart of accounts.
/// </summary>
public enum AccountCategory
{
    Asset = 1,
    Liability = 2,
    Equity = 3,
    Revenue = 4,
    Expense = 5
}

/// <summary>
/// Normal balance side for an account.
/// </summary>
public enum BalanceSide
{
    Debit = 1,
    Credit = 2
}
