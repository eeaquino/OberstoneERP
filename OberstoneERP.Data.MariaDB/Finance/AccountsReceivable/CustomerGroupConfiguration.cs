namespace OberstoneERP.Data.MariaDB.Finance.AccountsReceivable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for CustomerGroup.
/// </summary>
public class CustomerGroupConfiguration : BaseEntityConfiguration<CustomerGroup>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CustomerGroup> builder)
    {
        builder.ToTable("CustomerGroups");

        builder.Property(e => e.CompanyId).HasColumnType("char(36)").IsRequired();
        builder.HasIndex(e => e.CompanyId).HasDatabaseName("IX_CustomerGroups_CompanyId");
        builder.Property(e => e.Code).HasMaxLength(50).IsRequired();
        builder.HasIndex(e => new { e.CompanyId, e.Code }).IsUnique().HasDatabaseName("IX_CustomerGroups_CompanyId_Code");
        builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.DefaultPaymentTermsId).HasColumnType("char(36)");
        builder.Property(e => e.DefaultReceivableAccountId).HasColumnType("char(36)");
        builder.Property(e => e.DefaultRevenueAccountId).HasColumnType("char(36)");
        builder.Property(e => e.DefaultDiscountAccountId).HasColumnType("char(36)");
        builder.Property(e => e.CreditLimit).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.IsActive).HasDefaultValue(true).IsRequired();

        builder.HasOne(e => e.Company).WithMany().HasForeignKey(e => e.CompanyId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.DefaultPaymentTerms).WithMany().HasForeignKey(e => e.DefaultPaymentTermsId).OnDelete(DeleteBehavior.Restrict);
    }
}
