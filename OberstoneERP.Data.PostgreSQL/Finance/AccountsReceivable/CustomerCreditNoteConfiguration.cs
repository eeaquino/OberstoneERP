namespace OberstoneERP.Data.PostgreSQL.Finance.AccountsReceivable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for CustomerCreditNote.
/// </summary>
public class CustomerCreditNoteConfiguration : BaseEntityConfiguration<CustomerCreditNote>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CustomerCreditNote> builder)
    {
        builder.ToTable("CustomerCreditNotes", "accountsreceivable");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_CustomerCreditNotes_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("uuid");

        builder.Property(e => e.CustomerId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CustomerId)
            .HasDatabaseName("IX_CustomerCreditNotes_CustomerId");

        builder.Property(e => e.OriginalInvoiceId)
            .HasColumnType("uuid");

        builder.Property(e => e.CreditNoteNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.CreditNoteNumber })
            .IsUnique()
            .HasDatabaseName("IX_CustomerCreditNotes_CompanyId_CreditNoteNumber");

        builder.Property(e => e.CreditNoteDate)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(e => e.Reason)
            .HasConversion<int>()
            .IsRequired();

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

        builder.Property(e => e.TaxAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.TotalAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.AppliedAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        // RemainingCredit is computed, ignore it
        builder.Ignore(e => e.RemainingCredit);

        builder.Property(e => e.FunctionalAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(CustomerCreditNoteStatus.Draft)
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
            .WithMany(c => c.CreditNotes)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.OriginalInvoice)
            .WithMany()
            .HasForeignKey(e => e.OriginalInvoiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
