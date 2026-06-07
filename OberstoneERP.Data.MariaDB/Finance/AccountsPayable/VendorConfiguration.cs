namespace OberstoneERP.Data.MariaDB.Finance.AccountsPayable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for Vendor.
/// </summary>
public class VendorConfiguration : BaseEntityConfiguration<Vendor>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<Vendor> builder)
    {
        builder.ToTable("Vendors");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_Vendors_CompanyId");

        builder.Property(e => e.VendorGroupId)
            .HasColumnType("char(36)");

        builder.Property(e => e.VendorNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.VendorNumber })
            .IsUnique()
            .HasDatabaseName("IX_Vendors_CompanyId_VendorNumber");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Name })
            .HasDatabaseName("IX_Vendors_CompanyId_Name");

        builder.Property(e => e.LegalName)
            .HasMaxLength(300);

        builder.Property(e => e.VendorType)
            .HasConversion<int>()
            .HasDefaultValue(VendorType.Supplier)
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

        // Primary Address
        builder.Property(e => e.AddressLine1).HasMaxLength(200);
        builder.Property(e => e.AddressLine2).HasMaxLength(200);
        builder.Property(e => e.City).HasMaxLength(100);
        builder.Property(e => e.StateProvince).HasMaxLength(100);
        builder.Property(e => e.PostalCode).HasMaxLength(20);
        builder.Property(e => e.CountryCode).HasMaxLength(2);

        // Remittance Address
        builder.Property(e => e.RemitAddressLine1).HasMaxLength(200);
        builder.Property(e => e.RemitAddressLine2).HasMaxLength(200);
        builder.Property(e => e.RemitCity).HasMaxLength(100);
        builder.Property(e => e.RemitStateProvince).HasMaxLength(100);
        builder.Property(e => e.RemitPostalCode).HasMaxLength(20);
        builder.Property(e => e.RemitCountryCode).HasMaxLength(2);

        builder.Property(e => e.DefaultCurrencyId)
            .HasColumnType("char(36)");

        builder.Property(e => e.PaymentTermsId)
            .HasColumnType("char(36)");

        builder.Property(e => e.PreferredPaymentMethod)
            .HasConversion<int>()
            .HasDefaultValue(PaymentMethod.Check)
            .IsRequired();

        builder.Property(e => e.BankAccountNumber)
            .HasMaxLength(50);

        builder.Property(e => e.BankRoutingNumber)
            .HasMaxLength(50);

        builder.Property(e => e.BankName)
            .HasMaxLength(200);

        builder.Property(e => e.IBAN)
            .HasMaxLength(50);

        builder.Property(e => e.SwiftCode)
            .HasMaxLength(20);

        builder.Property(e => e.AccountsPayableBalance)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.DefaultTaxCodeId)
            .HasColumnType("char(36)");

        builder.Property(e => e.Is1099Required)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.Form1099Type)
            .HasMaxLength(20);

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.VendorGroup)
            .WithMany(vg => vg.Vendors)
            .HasForeignKey(e => e.VendorGroupId)
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
