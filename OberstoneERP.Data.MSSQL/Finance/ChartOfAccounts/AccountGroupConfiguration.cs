namespace OberstoneERP.Data.MSSQL.Finance.ChartOfAccounts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for AccountGroup.
/// </summary>
public class AccountGroupConfiguration : BaseEntityConfiguration<AccountGroup>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<AccountGroup> builder)
    {
        builder.ToTable("AccountGroups", "chartofaccounts");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_AccountGroups_CompanyId");

        builder.Property(e => e.ParentAccountGroupId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_AccountGroups_CompanyId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.Level)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.HierarchyPath)
            .HasMaxLength(500);

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.SortOrder)
            .HasDefaultValue(0)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ParentAccountGroup)
            .WithMany(e => e.ChildAccountGroups)
            .HasForeignKey(e => e.ParentAccountGroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
