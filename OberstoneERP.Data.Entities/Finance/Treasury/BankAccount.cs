namespace OberstoneERP.Data.Entities.Finance.Treasury;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents a bank account for cash management.
/// </summary>
public class BankAccount : BaseEntity
{
    /// <summary>
    /// Company this bank account belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Site this bank account is associated with.
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Unique code for the bank account.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name/description of the bank account.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Bank name.
    /// </summary>
    public string BankName { get; set; } = string.Empty;

    /// <summary>
    /// Bank branch name.
    /// </summary>
    public string? BranchName { get; set; }

    /// <summary>
    /// Bank account number.
    /// </summary>
    public string AccountNumber { get; set; } = string.Empty;

    /// <summary>
    /// IBAN (International Bank Account Number).
    /// </summary>
    public string? IBAN { get; set; }

    /// <summary>
    /// SWIFT/BIC code.
    /// </summary>
    public string? SwiftCode { get; set; }

    /// <summary>
    /// Bank routing number (ABA number in US).
    /// </summary>
    public string? RoutingNumber { get; set; }

    /// <summary>
    /// Type of bank account.
    /// </summary>
    public BankAccountType AccountType { get; set; }

    /// <summary>
    /// Currency ID for the bank account.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// General ledger account ID for this bank account.
    /// </summary>
    public Guid GLAccountId { get; set; }

    /// <summary>
    /// Current book balance.
    /// </summary>
    public decimal BookBalance { get; set; }

    /// <summary>
    /// Last known bank statement balance.
    /// </summary>
    public decimal StatementBalance { get; set; }

    /// <summary>
    /// Date of last bank statement.
    /// </summary>
    public DateTime? LastStatementDate { get; set; }

    /// <summary>
    /// Date of last reconciliation.
    /// </summary>
    public DateTime? LastReconciliationDate { get; set; }

    /// <summary>
    /// Minimum balance required.
    /// </summary>
    public decimal? MinimumBalance { get; set; }

    /// <summary>
    /// Overdraft limit.
    /// </summary>
    public decimal? OverdraftLimit { get; set; }

    /// <summary>
    /// Interest rate (for interest-bearing accounts).
    /// </summary>
    public decimal? InterestRate { get; set; }

    /// <summary>
    /// Account holder name.
    /// </summary>
    public string? AccountHolderName { get; set; }

    /// <summary>
    /// Bank address line 1.
    /// </summary>
    public string? BankAddressLine1 { get; set; }

    /// <summary>
    /// Bank address line 2.
    /// </summary>
    public string? BankAddressLine2 { get; set; }

    /// <summary>
    /// Bank city.
    /// </summary>
    public string? BankCity { get; set; }

    /// <summary>
    /// Bank state/province.
    /// </summary>
    public string? BankStateProvince { get; set; }

    /// <summary>
    /// Bank postal code.
    /// </summary>
    public string? BankPostalCode { get; set; }

    /// <summary>
    /// Bank country code.
    /// </summary>
    public string? BankCountryCode { get; set; }

    /// <summary>
    /// Contact phone number at the bank.
    /// </summary>
    public string? BankPhone { get; set; }

    /// <summary>
    /// Indicates if this is the primary bank account.
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// Indicates whether the bank account is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Next check number to use.
    /// </summary>
    public int NextCheckNumber { get; set; } = 1;

    /// <summary>
    /// Notes about the bank account.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Site? Site { get; set; }
    public virtual Currency Currency { get; set; } = null!;
    public virtual Account GLAccount { get; set; } = null!;
    public virtual ICollection<BankTransaction> Transactions { get; set; } = [];
    public virtual ICollection<BankReconciliation> Reconciliations { get; set; } = [];
}

/// <summary>
/// Types of bank accounts.
/// </summary>
public enum BankAccountType
{
    Checking = 0,
    Savings = 1,
    MoneyMarket = 2,
    CertificateOfDeposit = 3,
    LineOfCredit = 4,
    PettyCash = 5,
    Other = 99
}
