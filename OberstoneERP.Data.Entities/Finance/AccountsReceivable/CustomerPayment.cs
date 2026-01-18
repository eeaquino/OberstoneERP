namespace OberstoneERP.Data.Entities.Finance.AccountsReceivable;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.Treasury;

/// <summary>
/// Represents a payment received from a customer.
/// </summary>
public class CustomerPayment : BaseEntity
{
    /// <summary>
    /// Company this payment belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Site associated with this payment.
    /// </summary>
    public Guid? SiteId { get; set; }

    /// <summary>
    /// Customer ID.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Unique payment number.
    /// </summary>
    public string PaymentNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date the payment was received.
    /// </summary>
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// Payment method used.
    /// </summary>
    public PaymentMethod PaymentMethod { get; set; }

    /// <summary>
    /// Reference number (check number, transaction ID, etc.).
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// Bank account ID where payment was deposited.
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// Currency ID.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// Exchange rate to functional currency.
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// Total payment amount.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Amount in functional currency.
    /// </summary>
    public decimal FunctionalAmount { get; set; }

    /// <summary>
    /// Amount allocated to invoices.
    /// </summary>
    public decimal AllocatedAmount { get; set; }

    /// <summary>
    /// Unallocated amount (on account).
    /// </summary>
    public decimal UnallocatedAmount => Amount - AllocatedAmount;

    /// <summary>
    /// Status of the payment.
    /// </summary>
    public CustomerPaymentStatus Status { get; set; } = CustomerPaymentStatus.Draft;

    /// <summary>
    /// Date the payment was posted.
    /// </summary>
    public DateTime? PostedDate { get; set; }

    /// <summary>
    /// Associated journal entry ID.
    /// </summary>
    public Guid? JournalEntryId { get; set; }

    /// <summary>
    /// Bank transaction ID for reconciliation.
    /// </summary>
    public Guid? BankTransactionId { get; set; }

    /// <summary>
    /// Notes or comments.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Site? Site { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
    public virtual BankAccount? BankAccount { get; set; }
    public virtual ICollection<CustomerPaymentAllocation> Allocations { get; set; } = [];
}

/// <summary>
/// Payment methods.
/// </summary>
public enum PaymentMethod
{
    Cash = 0,
    Check = 1,
    BankTransfer = 2,
    CreditCard = 3,
    DebitCard = 4,
    DirectDebit = 5,
    Wire = 6,
    ACH = 7,
    PayPal = 8,
    Other = 99
}

/// <summary>
/// Status of a customer payment.
/// </summary>
public enum CustomerPaymentStatus
{
    Draft = 0,
    PendingApproval = 1,
    Approved = 2,
    Posted = 3,
    Deposited = 4,
    Reconciled = 5,
    Void = 6,
    Bounced = 7
}
