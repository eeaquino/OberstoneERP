namespace OberstoneERP.Data.Entities.Finance.AccountsPayable;

using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;

/// <summary>
/// Represents a grouping or classification of vendors.
/// </summary>
public class VendorGroup : BaseEntity
{
    /// <summary>
    /// Company this vendor group belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Unique code for the vendor group.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the vendor group.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the vendor group.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Default payment terms ID for vendors in this group.
    /// </summary>
    public Guid? DefaultPaymentTermsId { get; set; }

    /// <summary>
    /// Default AP control account ID.
    /// </summary>
    public Guid? DefaultPayableAccountId { get; set; }

    /// <summary>
    /// Default expense account ID.
    /// </summary>
    public Guid? DefaultExpenseAccountId { get; set; }

    /// <summary>
    /// Indicates whether the vendor group is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual PaymentTerms? DefaultPaymentTerms { get; set; }
    public virtual ICollection<Vendor> Vendors { get; set; } = [];
}
