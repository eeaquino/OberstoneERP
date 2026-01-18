namespace OberstoneERP.Data.Entities.Finance.Taxes;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents a tax code defining how taxes are calculated and posted.
/// </summary>
public class TaxCode : BaseEntity
{
    /// <summary>
    /// Company this tax code belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Unique code for the tax.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the tax code.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the tax code.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Type of tax.
    /// </summary>
    public TaxType TaxType { get; set; }

    /// <summary>
    /// Tax category for reporting purposes.
    /// </summary>
    public TaxCategory Category { get; set; }

    /// <summary>
    /// Country code where this tax applies (ISO 3166-1 alpha-2).
    /// </summary>
    public string? CountryCode { get; set; }

    /// <summary>
    /// State/Province code where this tax applies.
    /// </summary>
    public string? StateProvinceCode { get; set; }

    /// <summary>
    /// Tax authority name.
    /// </summary>
    public string? TaxAuthority { get; set; }

    /// <summary>
    /// Account ID for tax payable (sales tax collected).
    /// </summary>
    public Guid? TaxPayableAccountId { get; set; }

    /// <summary>
    /// Account ID for tax receivable (purchase tax paid).
    /// </summary>
    public Guid? TaxReceivableAccountId { get; set; }

    /// <summary>
    /// Account ID for tax expense (non-recoverable tax).
    /// </summary>
    public Guid? TaxExpenseAccountId { get; set; }

    /// <summary>
    /// Indicates if the tax is recoverable (can be claimed back).
    /// </summary>
    public bool IsRecoverable { get; set; } = true;

    /// <summary>
    /// Recovery percentage (100 = fully recoverable).
    /// </summary>
    public decimal RecoveryPercent { get; set; } = 100;

    /// <summary>
    /// Indicates if tax is calculated on gross or net amount.
    /// </summary>
    public TaxCalculationBasis CalculationBasis { get; set; } = TaxCalculationBasis.Net;

    /// <summary>
    /// Indicates if this is a compound tax (tax on tax).
    /// </summary>
    public bool IsCompound { get; set; }

    /// <summary>
    /// Indicates whether the tax code is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Sort order for display purposes.
    /// </summary>
    public int SortOrder { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual Account? TaxPayableAccount { get; set; }
    public virtual Account? TaxReceivableAccount { get; set; }
    public virtual Account? TaxExpenseAccount { get; set; }
    public virtual ICollection<TaxRate> TaxRates { get; set; } = [];
}

/// <summary>
/// Types of taxes.
/// </summary>
public enum TaxType
{
    /// <summary>
    /// Value Added Tax.
    /// </summary>
    VAT = 0,

    /// <summary>
    /// Sales Tax.
    /// </summary>
    SalesTax = 1,

    /// <summary>
    /// Goods and Services Tax.
    /// </summary>
    GST = 2,

    /// <summary>
    /// Use Tax.
    /// </summary>
    UseTax = 3,

    /// <summary>
    /// Withholding Tax.
    /// </summary>
    WithholdingTax = 4,

    /// <summary>
    /// Excise Tax.
    /// </summary>
    ExciseTax = 5,

    /// <summary>
    /// Import Duty.
    /// </summary>
    ImportDuty = 6,

    /// <summary>
    /// Other tax type.
    /// </summary>
    Other = 99
}

/// <summary>
/// Categories of taxes for reporting.
/// </summary>
public enum TaxCategory
{
    /// <summary>
    /// Standard rate tax.
    /// </summary>
    Standard = 0,

    /// <summary>
    /// Reduced rate tax.
    /// </summary>
    Reduced = 1,

    /// <summary>
    /// Zero rate tax.
    /// </summary>
    Zero = 2,

    /// <summary>
    /// Exempt from tax.
    /// </summary>
    Exempt = 3,

    /// <summary>
    /// Out of scope (not taxable).
    /// </summary>
    OutOfScope = 4,

    /// <summary>
    /// Reverse charge (customer pays tax).
    /// </summary>
    ReverseCharge = 5
}

/// <summary>
/// Basis for tax calculation.
/// </summary>
public enum TaxCalculationBasis
{
    /// <summary>
    /// Calculate tax on net amount (before tax).
    /// </summary>
    Net = 0,

    /// <summary>
    /// Calculate tax on gross amount (including other taxes).
    /// </summary>
    Gross = 1
}
