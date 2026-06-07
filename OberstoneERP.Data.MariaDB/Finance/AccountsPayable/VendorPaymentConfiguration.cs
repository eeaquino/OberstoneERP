namespace OberstoneERP.Data.MariaDB.Finance.AccountsPayable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for VendorPayment.
/// </summary>
public class VendorPaymentConfiguration : BaseEntityConfiguration<VendorPayment>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<VendorPayment> builder)
    {
        builder.ToTable("VendorPayments");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_VendorPayments_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("char(36)");

        builder.Property(e => e.VendorId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.VendorId)
            .HasDatabaseName("IX_VendorPayments_VendorId");

        builder.Property(e => e.PaymentNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.PaymentNumber })
            .IsUnique()
            .HasDatabaseName("IX_VendorPayments_CompanyId_PaymentNumber");

        builder.Property(e => e.PaymentDate)
            .HasColumnType("datetime(6)")
            .IsRequired();

        builder.Property(e => e.PaymentMethod)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Reference)
            .HasMaxLength(100);

        builder.Property(e => e.CheckNumber)
            .HasMaxLength(50);

        builder.Property(e => e.BankAccountId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.CurrencyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.ExchangeRate)
            .HasColumnType("decimal(19,8)")
            .HasDefaultValue(1m)
            .IsRequired();

        builder.Property(e => e.Amount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.FunctionalAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.AllocatedAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        // UnallocatedAmount is computed, ignore it
        builder.Ignore(e => e.UnallocatedAmount);

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(VendorPaymentStatus.Draft)
            .IsRequired();

        builder.Property(e => e.PostedDate)
            .HasColumnType("datetime(6)");

        builder.Property(e => e.CheckPrintedDate)
            .HasColumnType("datetime(6)");

        builder.Property(e => e.JournalEntryId)
            .HasColumnType("char(36)");

        builder.Property(e => e.BankTransactionId)
            .HasColumnType("char(36)");

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Site)
            .WithMany()
            .HasForeignKey(e => e.SiteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Vendor)
            .WithMany(v => v.Payments)
            .HasForeignKey(e => e.VendorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.BankAccount)
            .WithMany()
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
