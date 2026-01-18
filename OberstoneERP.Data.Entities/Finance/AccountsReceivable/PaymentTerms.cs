namespace OberstoneERP.Data.Entities.Finance.AccountsReceivable;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents payment terms that define when payment is due.
/// </summary>
public class PaymentTerms : BaseEntity
{
    /// <summary>
    /// Company this payment terms belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Unique code for the payment terms.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the payment terms.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the payment terms.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Number of days until payment is due.
    /// </summary>
    public int DueDays { get; set; }

    /// <summary>
    /// Due date calculation method.
    /// </summary>
    public DueDateMethod DueDateMethod { get; set; } = DueDateMethod.FromInvoiceDate;

    /// <summary>
    /// Day of month payment is due (for end of month calculations).
    /// </summary>
    public int? DueDayOfMonth { get; set; }

    /// <summary>
    /// Early payment discount percentage.
    /// </summary>
    public decimal DiscountPercent { get; set; }

    /// <summary>
    /// Days within which discount applies.
    /// </summary>
    public int DiscountDays { get; set; }

    /// <summary>
    /// Indicates whether the payment terms are active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
}

/// <summary>
/// Methods for calculating due dates.
/// </summary>
public enum DueDateMethod
{
    FromInvoiceDate = 0,
    EndOfMonth = 1,
    EndOfNextMonth = 2,
    FixedDayOfMonth = 3
}
