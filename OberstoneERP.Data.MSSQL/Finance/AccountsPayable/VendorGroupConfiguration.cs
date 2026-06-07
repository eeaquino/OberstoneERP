namespace OberstoneERP.Data.MSSQL.Finance.AccountsPayable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for VendorGroup.
/// </summary>
public class VendorGroupConfiguration : BaseEntityConfiguration<VendorGroup>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<VendorGroup> builder)
    {
        builder.ToTable("VendorGroups", "accountspayable");

        builder.Property(e => e.CompanyId).HasColumnType("uniqueidentifier").IsRequired();
        builder.HasIndex(e => e.CompanyId).HasDatabaseName("IX_VendorGroups_CompanyId");
        builder.Property(e => e.Code).HasMaxLength(50).IsRequired();
        builder.HasIndex(e => new { e.CompanyId, e.Code }).IsUnique().HasDatabaseName("IX_VendorGroups_CompanyId_Code");
        builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.DefaultPaymentTermsId).HasColumnType("uniqueidentifier");
        builder.Property(e => e.DefaultPayableAccountId).HasColumnType("uniqueidentifier");
        builder.Property(e => e.DefaultExpenseAccountId).HasColumnType("uniqueidentifier");
        builder.Property(e => e.IsActive).HasDefaultValue(true).IsRequired();

        builder.HasOne(e => e.Company).WithMany().HasForeignKey(e => e.CompanyId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.DefaultPaymentTerms).WithMany().HasForeignKey(e => e.DefaultPaymentTermsId).OnDelete(DeleteBehavior.Restrict);
    }
}
