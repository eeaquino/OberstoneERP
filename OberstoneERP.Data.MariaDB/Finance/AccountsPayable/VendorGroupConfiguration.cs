namespace OberstoneERP.Data.MariaDB.Finance.AccountsPayable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for VendorGroup.
/// </summary>
public class VendorGroupConfiguration : BaseEntityConfiguration<VendorGroup>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<VendorGroup> builder)
    {
        builder.ToTable("VendorGroups");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_VendorGroups_CompanyId");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_VendorGroups_CompanyId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.DefaultPaymentTermsId)
            .HasColumnType("char(36)");

        builder.Property(e => e.DefaultPayableAccountId)
            .HasColumnType("char(36)");

        builder.Property(e => e.DefaultExpenseAccountId)
            .HasColumnType("char(36)");

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.DefaultPaymentTerms)
            .WithMany()
            .HasForeignKey(e => e.DefaultPaymentTermsId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
