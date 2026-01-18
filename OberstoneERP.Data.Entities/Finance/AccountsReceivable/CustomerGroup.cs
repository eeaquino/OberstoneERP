namespace OberstoneERP.Data.Entities.Finance.AccountsReceivable;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a grouping or classification of customers.
/// </summary>
public class CustomerGroup : BaseEntity
{
    /// <summary>
    /// Company this customer group belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Unique code for the customer group.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the customer group.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the customer group.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Default payment terms ID for customers in this group.
    /// </summary>
    public Guid? DefaultPaymentTermsId { get; set; }

    /// <summary>
    /// Default AR control account ID.
    /// </summary>
    public Guid? DefaultReceivableAccountId { get; set; }

    /// <summary>
    /// Default revenue account ID.
    /// </summary>
    public Guid? DefaultRevenueAccountId { get; set; }

    /// <summary>
    /// Default discount account ID.
    /// </summary>
    public Guid? DefaultDiscountAccountId { get; set; }

    /// <summary>
    /// Credit limit for customers in this group (0 = no limit).
    /// </summary>
    public decimal CreditLimit { get; set; }

    /// <summary>
    /// Indicates whether the customer group is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual PaymentTerms? DefaultPaymentTerms { get; set; }
    public virtual ICollection<Customer> Customers { get; set; } = [];
}
