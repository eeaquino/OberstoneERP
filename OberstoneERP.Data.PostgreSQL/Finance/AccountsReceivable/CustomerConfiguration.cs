namespace OberstoneERP.Data.PostgreSQL.Finance.AccountsReceivable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for Customer.
/// </summary>
public class CustomerConfiguration : BaseEntityConfiguration<Customer>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers", "accountsreceivable");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_Customers_CompanyId");

        builder.Property(e => e.CustomerGroupId)
            .HasColumnType("uuid");

        builder.Property(e => e.CustomerNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.CustomerNumber })
            .IsUnique()
            .HasDatabaseName("IX_Customers_CompanyId_CustomerNumber");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Name })
            .HasDatabaseName("IX_Customers_CompanyId_Name");

        builder.Property(e => e.LegalName)
            .HasMaxLength(300);

        builder.Property(e => e.CustomerType)
            .HasConversion<int>()
            .HasDefaultValue(CustomerType.Business)
            .IsRequired();

        builder.Property(e => e.TaxId)
            .HasMaxLength(50);

        builder.Property(e => e.ContactName)
            .HasMaxLength(200);

        builder.Property(e => e.Email)
            .HasMaxLength(256);

        builder.Property(e => e.Phone)
            .HasMaxLength(50);

        builder.Property(e => e.Phone2)
            .HasMaxLength(50);

        builder.Property(e => e.Fax)
            .HasMaxLength(50);

        builder.Property(e => e.Website)
            .HasMaxLength(256);

        // Billing Address
        builder.Property(e => e.BillingAddressLine1).HasMaxLength(200);
        builder.Property(e => e.BillingAddressLine2).HasMaxLength(200);
        builder.Property(e => e.BillingCity).HasMaxLength(100);
        builder.Property(e => e.BillingStateProvince).HasMaxLength(100);
        builder.Property(e => e.BillingPostalCode).HasMaxLength(20);
        builder.Property(e => e.BillingCountryCode).HasMaxLength(2);

        // Shipping Address
        builder.Property(e => e.ShippingAddressLine1).HasMaxLength(200);
        builder.Property(e => e.ShippingAddressLine2).HasMaxLength(200);
        builder.Property(e => e.ShippingCity).HasMaxLength(100);
        builder.Property(e => e.ShippingStateProvince).HasMaxLength(100);
        builder.Property(e => e.ShippingPostalCode).HasMaxLength(20);
        builder.Property(e => e.ShippingCountryCode).HasMaxLength(2);

        builder.Property(e => e.DefaultCurrencyId)
            .HasColumnType("uuid");

        builder.Property(e => e.PaymentTermsId)
            .HasColumnType("uuid");

        builder.Property(e => e.CreditLimit)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.CreditUsed)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        // CreditAvailable is computed, ignore it
        builder.Ignore(e => e.CreditAvailable);

        builder.Property(e => e.CreditCheckEnabled)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.CreditStatus)
            .HasConversion<int>()
            .HasDefaultValue(CreditStatus.Good)
            .IsRequired();

        builder.Property(e => e.AccountsReceivableBalance)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.DefaultTaxCodeId)
            .HasColumnType("uuid");

        builder.Property(e => e.IsTaxExempt)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.TaxExemptionNumber)
            .HasMaxLength(100);

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.CustomerGroup)
            .WithMany(cg => cg.Customers)
            .HasForeignKey(e => e.CustomerGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.DefaultCurrency)
            .WithMany()
            .HasForeignKey(e => e.DefaultCurrencyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.PaymentTerms)
            .WithMany()
            .HasForeignKey(e => e.PaymentTermsId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
