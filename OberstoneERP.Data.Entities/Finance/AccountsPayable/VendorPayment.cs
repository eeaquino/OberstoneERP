namespace OberstoneERP.Data.Entities.Finance.AccountsPayable;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.Entities.Finance.Treasury;

/// <summary>
/// Represents a payment made to a vendor.
/// </summary>
public class VendorPayment : BaseEntity
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
    /// Vendor ID.
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// Unique payment number.
    /// </summary>
    public string PaymentNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date the payment was made.
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
    /// Check number if paid by check.
    /// </summary>
    public string? CheckNumber { get; set; }

    /// <summary>
    /// Bank account ID the payment is made from.
    /// </summary>
    public Guid BankAccountId { get; set; }

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
    /// Unallocated amount (prepayment).
    /// </summary>
    public decimal UnallocatedAmount => Amount - AllocatedAmount;

    /// <summary>
    /// Status of the payment.
    /// </summary>
    public VendorPaymentStatus Status { get; set; } = VendorPaymentStatus.Draft;

    /// <summary>
    /// Date the payment was posted.
    /// </summary>
    public DateTime? PostedDate { get; set; }

    /// <summary>
    /// Check print date.
    /// </summary>
    public DateTime? CheckPrintedDate { get; set; }

    /// <summary>
    /// Date the check cleared the bank.
    /// </summary>
    public DateTime? ClearedDate { get; set; }

    /// <summary>
    /// Associated journal entry ID.
    /// </summary>
    public Guid? JournalEntryId { get; set; }

    /// <summary>
    /// Bank transaction ID for reconciliation.
    /// </summary>
    public Guid? BankTransactionId { get; set; }

    /// <summary>
    /// User who approved the payment.
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// Date the payment was approved.
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// Remittance advice notes.
    /// </summary>
    public string? RemittanceNotes { get; set; }

    /// <summary>
    /// Notes or comments.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Site? Site { get; set; }
    public virtual Vendor Vendor { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
    public virtual BankAccount BankAccount { get; set; } = null!;
    public virtual ICollection<VendorPaymentAllocation> Allocations { get; set; } = [];
}

/// <summary>
/// Status of a vendor payment.
/// </summary>
public enum VendorPaymentStatus
{
    Draft = 0,
    PendingApproval = 1,
    Approved = 2,
    Printed = 3,
    Posted = 4,
    Cleared = 5,
    Reconciled = 6,
    Void = 7,
    Stopped = 8
}
