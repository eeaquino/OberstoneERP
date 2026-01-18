namespace OberstoneERP.Data.PostgreSQL.Finance.AccountsReceivable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for CustomerGroup.
/// </summary>
public class CustomerGroupConfiguration : BaseEntityConfiguration<CustomerGroup>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CustomerGroup> builder)
    {
        builder.ToTable("CustomerGroups", "accountsreceivable");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_CustomerGroups_CompanyId");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_CustomerGroups_CompanyId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.DefaultPaymentTermsId)
            .HasColumnType("uuid");

        builder.Property(e => e.DefaultReceivableAccountId)
            .HasColumnType("uuid");

        builder.Property(e => e.DefaultRevenueAccountId)
            .HasColumnType("uuid");

        builder.Property(e => e.DefaultDiscountAccountId)
            .HasColumnType("uuid");

        builder.Property(e => e.CreditLimit)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

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
