namespace OberstoneERP.Data.Entities.Finance.AccountsReceivable;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents a line item on a customer credit note.
/// </summary>
public class CustomerCreditNoteLine : BaseEntity
{
    /// <summary>
    /// Credit note this line belongs to.
    /// </summary>
    public Guid CustomerCreditNoteId { get; set; }

    /// <summary>
    /// Line number within the credit note.
    /// </summary>
    public int LineNumber { get; set; }

    /// <summary>
    /// Item/product code (if applicable).
    /// </summary>
    public string? ItemCode { get; set; }

    /// <summary>
    /// Description of the line item.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Account ID for the credit.
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// Quantity.
    /// </summary>
    public decimal Quantity { get; set; } = 1;

    /// <summary>
    /// Unit of measure.
    /// </summary>
    public string? UnitOfMeasure { get; set; }

    /// <summary>
    /// Unit price.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Net amount.
    /// </summary>
    public decimal NetAmount { get; set; }

    /// <summary>
    /// Tax code ID.
    /// </summary>
    public Guid? TaxCodeId { get; set; }

    /// <summary>
    /// Tax amount for this line.
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// Total line amount including tax.
    /// </summary>
    public decimal TotalAmount { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual CustomerCreditNote CustomerCreditNote { get; set; } = null!;
    public virtual Account Account { get; set; } = null!;
}
