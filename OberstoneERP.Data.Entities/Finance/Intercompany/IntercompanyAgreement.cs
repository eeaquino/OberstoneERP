namespace OberstoneERP.Data.Entities.Finance.Intercompany;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

/// <summary>
/// Represents an intercompany agreement between two companies within the same tenant.
/// </summary>
public class IntercompanyAgreement : BaseEntity
{
    /// <summary>
    /// Source company ID (seller/provider).
    /// </summary>
    public Guid SourceCompanyId { get; set; }

    /// <summary>
    /// Target company ID (buyer/receiver).
    /// </summary>
    public Guid TargetCompanyId { get; set; }

    /// <summary>
    /// Unique agreement number.
    /// </summary>
    public string AgreementNumber { get; set; } = string.Empty;

    /// <summary>
    /// Name/description of the agreement.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Detailed description of the agreement.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Type of intercompany relationship.
    /// </summary>
    public IntercompanyAgreementType AgreementType { get; set; }

    /// <summary>
    /// Effective start date of the agreement.
    /// </summary>
    public DateTime EffectiveFrom { get; set; }

    /// <summary>
    /// Effective end date of the agreement.
    /// </summary>
    public DateTime? EffectiveTo { get; set; }

    /// <summary>
    /// Currency ID for the agreement.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// Receivable account ID in source company.
    /// </summary>
    public Guid SourceReceivableAccountId { get; set; }

    /// <summary>
    /// Payable account ID in target company.
    /// </summary>
    public Guid TargetPayableAccountId { get; set; }

    /// <summary>
    /// Revenue account ID in source company.
    /// </summary>
    public Guid? SourceRevenueAccountId { get; set; }

    /// <summary>
    /// Expense account ID in target company.
    /// </summary>
    public Guid? TargetExpenseAccountId { get; set; }

    /// <summary>
    /// Markup percentage for cost-plus pricing.
    /// </summary>
    public decimal MarkupPercent { get; set; }

    /// <summary>
    /// Status of the agreement.
    /// </summary>
    public IntercompanyAgreementStatus Status { get; set; } = IntercompanyAgreementStatus.Active;

    /// <summary>
    /// Indicates if automatic elimination entries should be created.
    /// </summary>
    public bool AutoCreateElimination { get; set; } = true;

    /// <summary>
    /// Notes about the agreement.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company SourceCompany { get; set; } = null!;
    public virtual Company TargetCompany { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
    public virtual Account SourceReceivableAccount { get; set; } = null!;
    public virtual Account TargetPayableAccount { get; set; } = null!;
    public virtual ICollection<IntercompanyTransaction> Transactions { get; set; } = [];
}

/// <summary>
/// Types of intercompany agreements.
/// </summary>
public enum IntercompanyAgreementType
{
    /// <summary>
    /// Sale of goods between companies.
    /// </summary>
    SaleOfGoods = 0,

    /// <summary>
    /// Service agreement.
    /// </summary>
    ServiceAgreement = 1,

    /// <summary>
    /// Management fee.
    /// </summary>
    ManagementFee = 2,

    /// <summary>
    /// Royalty or license fee.
    /// </summary>
    RoyaltyLicense = 3,

    /// <summary>
    /// Cost sharing agreement.
    /// </summary>
    CostSharing = 4,

    /// <summary>
    /// Intercompany loan.
    /// </summary>
    Loan = 5,

    /// <summary>
    /// Other type of agreement.
    /// </summary>
    Other = 99
}

/// <summary>
/// Status of an intercompany agreement.
/// </summary>
public enum IntercompanyAgreementStatus
{
    Draft = 0,
    PendingApproval = 1,
    Active = 2,
    Suspended = 3,
    Expired = 4,
    Terminated = 5
}
