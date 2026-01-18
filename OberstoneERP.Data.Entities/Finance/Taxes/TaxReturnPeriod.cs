namespace OberstoneERP.Data.Entities.Finance.Taxes;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a tax return period for filing tax returns.
/// </summary>
public class TaxReturnPeriod : BaseEntity
{
    /// <summary>
    /// Company this tax return period belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Name/description of the period (e.g., "Q1 2024 VAT Return").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Tax authority this return is filed with.
    /// </summary>
    public string? TaxAuthority { get; set; }

    /// <summary>
    /// Type of tax return.
    /// </summary>
    public TaxReturnType ReturnType { get; set; }

    /// <summary>
    /// Start date of the period.
    /// </summary>
    public DateTime PeriodStartDate { get; set; }

    /// <summary>
    /// End date of the period.
    /// </summary>
    public DateTime PeriodEndDate { get; set; }

    /// <summary>
    /// Filing due date.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Total output tax (sales tax collected).
    /// </summary>
    public decimal OutputTax { get; set; }

    /// <summary>
    /// Total input tax (purchase tax paid).
    /// </summary>
    public decimal InputTax { get; set; }

    /// <summary>
    /// Net tax due (Output - Input, positive = payable, negative = refund).
    /// </summary>
    public decimal NetTaxDue => OutputTax - InputTax;

    /// <summary>
    /// Status of the tax return.
    /// </summary>
    public TaxReturnStatus Status { get; set; } = TaxReturnStatus.Open;

    /// <summary>
    /// Date the return was filed.
    /// </summary>
    public DateTime? FiledDate { get; set; }

    /// <summary>
    /// Reference number from tax authority.
    /// </summary>
    public string? FilingReference { get; set; }

    /// <summary>
    /// Date payment was made.
    /// </summary>
    public DateTime? PaymentDate { get; set; }

    /// <summary>
    /// Payment reference number.
    /// </summary>
    public string? PaymentReference { get; set; }

    /// <summary>
    /// Notes about the return.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
}

/// <summary>
/// Types of tax returns.
/// </summary>
public enum TaxReturnType
{
    VAT = 0,
    SalesTax = 1,
    GST = 2,
    WithholdingTax = 3,
    Annual = 4,
    Other = 99
}

/// <summary>
/// Status of a tax return.
/// </summary>
public enum TaxReturnStatus
{
    Open = 0,
    InProgress = 1,
    PendingReview = 2,
    Filed = 3,
    Paid = 4,
    Amended = 5,
    Closed = 6
}
