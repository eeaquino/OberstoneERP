namespace OberstoneERP.Data.Entities.Finance.AccountsPayable;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;

/// <summary>
/// Represents a vendor/supplier in the accounts payable system.
/// </summary>
public class Vendor : BaseEntity
{
    /// <summary>
    /// Company this vendor belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Vendor group ID.
    /// </summary>
    public Guid? VendorGroupId { get; set; }

    /// <summary>
    /// Unique vendor number/code.
    /// </summary>
    public string VendorNumber { get; set; } = string.Empty;

    /// <summary>
    /// Vendor name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Legal name of the vendor.
    /// </summary>
    public string? LegalName { get; set; }

    /// <summary>
    /// Vendor type.
    /// </summary>
    public VendorType VendorType { get; set; } = VendorType.Supplier;

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

    // Primary Address
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? StateProvince { get; set; }
    public string? PostalCode { get; set; }
    public string? CountryCode { get; set; }

    // Remittance Address (where to send payments)
    public string? RemitAddressLine1 { get; set; }
    public string? RemitAddressLine2 { get; set; }
    public string? RemitCity { get; set; }
    public string? RemitStateProvince { get; set; }
    public string? RemitPostalCode { get; set; }
    public string? RemitCountryCode { get; set; }

    /// <summary>
    /// Default currency ID for the vendor.
    /// </summary>
    public Guid? DefaultCurrencyId { get; set; }

    /// <summary>
    /// Default payment terms ID.
    /// </summary>
    public Guid? PaymentTermsId { get; set; }

    /// <summary>
    /// Preferred payment method.
    /// </summary>
    public PaymentMethod PreferredPaymentMethod { get; set; } = PaymentMethod.Check;

    /// <summary>
    /// Bank account number for electronic payments.
    /// </summary>
    public string? BankAccountNumber { get; set; }

    /// <summary>
    /// Bank routing number.
    /// </summary>
    public string? BankRoutingNumber { get; set; }

    /// <summary>
    /// Bank name.
    /// </summary>
    public string? BankName { get; set; }

    /// <summary>
    /// IBAN for international transfers.
    /// </summary>
    public string? IBAN { get; set; }

    /// <summary>
    /// SWIFT/BIC code for international transfers.
    /// </summary>
    public string? SwiftCode { get; set; }

    /// <summary>
    /// Current accounts payable balance.
    /// </summary>
    public decimal AccountsPayableBalance { get; set; }

    /// <summary>
    /// Default tax code ID.
    /// </summary>
    public Guid? DefaultTaxCodeId { get; set; }

    /// <summary>
    /// Indicates if 1099 reporting is required (US).
    /// </summary>
    public bool Is1099Required { get; set; }

    /// <summary>
    /// 1099 type if applicable.
    /// </summary>
    public string? Form1099Type { get; set; }

    /// <summary>
    /// Withholding tax applies.
    /// </summary>
    public bool WithholdingTaxApplies { get; set; }

    /// <summary>
    /// Withholding tax rate.
    /// </summary>
    public decimal WithholdingTaxRate { get; set; }

    /// <summary>
    /// Indicates whether the vendor is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Notes about the vendor.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual VendorGroup? VendorGroup { get; set; }
    public virtual Currency? DefaultCurrency { get; set; }
    public virtual PaymentTerms? PaymentTerms { get; set; }
    public virtual ICollection<VendorInvoice> Invoices { get; set; } = [];
    public virtual ICollection<VendorPayment> Payments { get; set; } = [];
    public virtual ICollection<VendorDebitNote> DebitNotes { get; set; } = [];
}

/// <summary>
/// Types of vendors.
/// </summary>
public enum VendorType
{
    Supplier = 0,
    Contractor = 1,
    ServiceProvider = 2,
    Employee = 3,
    Government = 4,
    Utility = 5,
    Other = 99
}
