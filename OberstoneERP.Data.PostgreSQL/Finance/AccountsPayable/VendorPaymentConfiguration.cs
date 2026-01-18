namespace OberstoneERP.Data.PostgreSQL.Finance.AccountsPayable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for VendorPayment.
/// </summary>
public class VendorPaymentConfiguration : BaseEntityConfiguration<VendorPayment>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<VendorPayment> builder)
    {
        builder.ToTable("VendorPayments", "accountspayable");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_VendorPayments_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("uuid");

        builder.Property(e => e.VendorId)
            .HasColumnType("uuid")
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
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(e => e.PaymentMethod)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Reference)
            .HasMaxLength(100);

        builder.Property(e => e.CheckNumber)
            .HasMaxLength(50);

        builder.Property(e => e.BankAccountId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(e => e.CurrencyId)
            .HasColumnType("uuid")
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
            .HasColumnType("timestamp with time zone");

        builder.Property(e => e.CheckPrintedDate)
            .HasColumnType("timestamp with time zone");

        builder.Property(e => e.JournalEntryId)
            .HasColumnType("uuid");

        builder.Property(e => e.BankTransactionId)
            .HasColumnType("uuid");

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
