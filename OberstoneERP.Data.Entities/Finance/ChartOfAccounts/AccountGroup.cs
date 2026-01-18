namespace OberstoneERP.Data.Entities.Finance.ChartOfAccounts;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a grouping of accounts for reporting and organizational purposes.
/// Account groups can be hierarchical.
/// </summary>
public class AccountGroup : BaseEntity
{
    /// <summary>
    /// Company this account group belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Parent account group ID for hierarchical structure.
    /// </summary>
    public Guid? ParentAccountGroupId { get; set; }

    /// <summary>
    /// Unique code for the account group within the company.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the account group.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the account group.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Hierarchical level (0 = root level).
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// Full hierarchical path (e.g., "1000.1100.1110").
    /// </summary>
    public string? HierarchyPath { get; set; }

    /// <summary>
    /// Indicates whether the account group is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Sort order for display purposes within the same level.
    /// </summary>
    public int SortOrder { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual AccountGroup? ParentAccountGroup { get; set; }
    public virtual ICollection<AccountGroup> ChildAccountGroups { get; set; } = [];
    public virtual ICollection<Account> Accounts { get; set; } = [];
}
