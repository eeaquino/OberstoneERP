namespace OberstoneERP.Data.Entities.Finance.Taxes;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents a tax transaction record for audit and reporting purposes.
/// </summary>
public class TaxTransaction : BaseEntity
{
    /// <summary>
    /// Company this tax transaction belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Tax code used.
    /// </summary>
    public Guid TaxCodeId { get; set; }

    /// <summary>
    /// Tax rate applied.
    /// </summary>
    public Guid TaxRateId { get; set; }

    /// <summary>
    /// Source document type.
    /// </summary>
    public TaxSourceDocumentType SourceDocumentType { get; set; }

    /// <summary>
    /// Source document ID.
    /// </summary>
    public Guid SourceDocumentId { get; set; }

    /// <summary>
    /// Source document line ID (if applicable).
    /// </summary>
    public Guid? SourceDocumentLineId { get; set; }

    /// <summary>
    /// Source document number for reference.
    /// </summary>
    public string? SourceDocumentNumber { get; set; }

    /// <summary>
    /// Date of the transaction.
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// Fiscal period ID.
    /// </summary>
    public Guid FiscalPeriodId { get; set; }

    /// <summary>
    /// Direction of tax (input = purchase, output = sales).
    /// </summary>
    public TaxDirection Direction { get; set; }

    /// <summary>
    /// Taxable base amount.
    /// </summary>
    public decimal TaxableAmount { get; set; }

    /// <summary>
    /// Tax rate percentage applied.
    /// </summary>
    public decimal TaxRatePercent { get; set; }

    /// <summary>
    /// Calculated tax amount.
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// Recoverable portion of the tax.
    /// </summary>
    public decimal RecoverableAmount { get; set; }

    /// <summary>
    /// Non-recoverable portion (expensed).
    /// </summary>
    public decimal NonRecoverableAmount { get; set; }

    /// <summary>
    /// Currency ID.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// Exchange rate to functional currency.
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// Tax amount in functional currency.
    /// </summary>
    public decimal FunctionalTaxAmount { get; set; }

    /// <summary>
    /// Customer ID (for output tax).
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Customer tax ID for reporting.
    /// </summary>
    public string? CustomerTaxId { get; set; }

    /// <summary>
    /// Vendor ID (for input tax).
    /// </summary>
    public Guid? VendorId { get; set; }

    /// <summary>
    /// Vendor tax ID for reporting.
    /// </summary>
    public string? VendorTaxId { get; set; }

    /// <summary>
    /// Status of the tax transaction.
    /// </summary>
    public TaxTransactionStatus Status { get; set; } = TaxTransactionStatus.Open;

    /// <summary>
    /// Tax return period this transaction is included in.
    /// </summary>
    public Guid? TaxReturnPeriodId { get; set; }

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
    public virtual TaxCode TaxCode { get; set; } = null!;
    public virtual TaxRate TaxRate { get; set; } = null!;
    public virtual FiscalPeriod FiscalPeriod { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
}

/// <summary>
/// Source document types for tax transactions.
/// </summary>
public enum TaxSourceDocumentType
{
    CustomerInvoice = 0,
    CustomerCreditNote = 1,
    VendorInvoice = 2,
    VendorDebitNote = 3,
    JournalEntry = 4,
    Adjustment = 5
}

/// <summary>
/// Direction of tax (input or output).
/// </summary>
public enum TaxDirection
{
    /// <summary>
    /// Input tax (purchase tax paid).
    /// </summary>
    Input = 0,

    /// <summary>
    /// Output tax (sales tax collected).
    /// </summary>
    Output = 1
}

/// <summary>
/// Status of a tax transaction.
/// </summary>
public enum TaxTransactionStatus
{
    /// <summary>
    /// Transaction is open and not yet reported.
    /// </summary>
    Open = 0,

    /// <summary>
    /// Transaction is included in a tax return.
    /// </summary>
    Reported = 1,

    /// <summary>
    /// Transaction has been settled/paid.
    /// </summary>
    Settled = 2,

    /// <summary>
    /// Transaction has been reversed.
    /// </summary>
    Reversed = 3,

    /// <summary>
    /// Transaction is void.
    /// </summary>
    Void = 4
}
