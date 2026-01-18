namespace OberstoneERP.Data.PostgreSQL.Finance.AccountsReceivable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for CustomerInvoice.
/// </summary>
public class CustomerInvoiceConfiguration : BaseEntityConfiguration<CustomerInvoice>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CustomerInvoice> builder)
    {
        builder.ToTable("CustomerInvoices", "accountsreceivable");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_CustomerInvoices_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("uuid");

        builder.Property(e => e.CustomerId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CustomerId)
            .HasDatabaseName("IX_CustomerInvoices_CustomerId");

        builder.Property(e => e.InvoiceNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.InvoiceNumber })
            .IsUnique()
            .HasDatabaseName("IX_CustomerInvoices_CompanyId_InvoiceNumber");

        builder.Property(e => e.InvoiceDate)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(e => e.DueDate)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.DueDate })
            .HasDatabaseName("IX_CustomerInvoices_CompanyId_DueDate");

        builder.Property(e => e.PaymentTermsId)
            .HasColumnType("uuid");

        builder.Property(e => e.CustomerPurchaseOrder)
            .HasMaxLength(100);

        builder.Property(e => e.Reference)
            .HasMaxLength(500);

        builder.Property(e => e.CurrencyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(e => e.ExchangeRate)
            .HasColumnType("decimal(19,8)")
            .HasDefaultValue(1m)
            .IsRequired();

        builder.Property(e => e.Subtotal)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.DiscountAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.TaxAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.TotalAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.PaidAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        // BalanceDue is computed, ignore it
        builder.Ignore(e => e.BalanceDue);

        builder.Property(e => e.FunctionalAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(CustomerInvoiceStatus.Draft)
            .IsRequired();

        builder.Property(e => e.PostedDate)
            .HasColumnType("timestamp with time zone");

        builder.Property(e => e.JournalEntryId)
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

        builder.HasOne(e => e.Customer)
            .WithMany(c => c.Invoices)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.PaymentTerms)
            .WithMany()
            .HasForeignKey(e => e.PaymentTermsId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
