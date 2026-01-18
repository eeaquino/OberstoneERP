namespace OberstoneERP.Data.Entities.Finance.AccountsReceivable;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a customer in the accounts receivable system.
/// </summary>
public class Customer : BaseEntity
{
    /// <summary>
    /// Company this customer belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Customer group ID.
    /// </summary>
    public Guid? CustomerGroupId { get; set; }

    /// <summary>
    /// Unique customer number/code.
    /// </summary>
    public string CustomerNumber { get; set; } = string.Empty;

    /// <summary>
    /// Customer name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Legal name of the customer.
    /// </summary>
    public string? LegalName { get; set; }

    /// <summary>
    /// Customer type.
    /// </summary>
    public CustomerType CustomerType { get; set; } = CustomerType.Business;

    /// <summary>
    /// Tax identification number.
    /// </summary>
    public string? TaxId { get; set; }

    /// <summary>
    /// Primary contact name.
    /// </summary>
    public string? ContactName { get; set; }

    /// <summary>
    /// Primary email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Primary phone number.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Secondary phone number.
    /// </summary>
    public string? Phone2 { get; set; }

    /// <summary>
    /// Fax number.
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// Website URL.
    /// </summary>
    public string? Website { get; set; }

    // Billing Address
    public string? BillingAddressLine1 { get; set; }
    public string? BillingAddressLine2 { get; set; }
    public string? BillingCity { get; set; }
    public string? BillingStateProvince { get; set; }
    public string? BillingPostalCode { get; set; }
    public string? BillingCountryCode { get; set; }

    // Shipping Address
    public string? ShippingAddressLine1 { get; set; }
    public string? ShippingAddressLine2 { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingStateProvince { get; set; }
    public string? ShippingPostalCode { get; set; }
    public string? ShippingCountryCode { get; set; }

    /// <summary>
    /// Default currency ID for the customer.
    /// </summary>
    public Guid? DefaultCurrencyId { get; set; }

    /// <summary>
    /// Default payment terms ID.
    /// </summary>
    public Guid? PaymentTermsId { get; set; }

    /// <summary>
    /// Credit limit for the customer (0 = no limit).
    /// </summary>
    public decimal CreditLimit { get; set; }

    /// <summary>
    /// Current credit used.
    /// </summary>
    public decimal CreditUsed { get; set; }

    /// <summary>
    /// Available credit (limit - used).
    /// </summary>
    public decimal CreditAvailable => CreditLimit - CreditUsed;

    /// <summary>
    /// Indicates if credit check should be performed.
    /// </summary>
    public bool CreditCheckEnabled { get; set; } = true;

    /// <summary>
    /// Credit status.
    /// </summary>
    public CreditStatus CreditStatus { get; set; } = CreditStatus.Good;

    /// <summary>
    /// Current accounts receivable balance.
    /// </summary>
    public decimal AccountsReceivableBalance { get; set; }

    /// <summary>
    /// Default tax code ID.
    /// </summary>
    public Guid? DefaultTaxCodeId { get; set; }

    /// <summary>
    /// Indicates if the customer is tax exempt.
    /// </summary>
    public bool IsTaxExempt { get; set; }

    /// <summary>
    /// Tax exemption certificate number.
    /// </summary>
    public string? TaxExemptionNumber { get; set; }

    /// <summary>
    /// Indicates whether the customer is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Notes about the customer.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual CustomerGroup? CustomerGroup { get; set; }
    public virtual Currency? DefaultCurrency { get; set; }
    public virtual PaymentTerms? PaymentTerms { get; set; }
    public virtual ICollection<CustomerInvoice> Invoices { get; set; } = [];
    public virtual ICollection<CustomerPayment> Payments { get; set; } = [];
    public virtual ICollection<CustomerCreditNote> CreditNotes { get; set; } = [];
}

/// <summary>
/// Types of customers.
/// </summary>
public enum CustomerType
{
    Individual = 0,
    Business = 1,
    Government = 2,
    NonProfit = 3
}

/// <summary>
/// Customer credit status.
/// </summary>
public enum CreditStatus
{
    Good = 0,
    Warning = 1,
    Hold = 2,
    Blocked = 3
}
