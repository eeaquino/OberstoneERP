namespace OberstoneERP.Data.MariaDB.Finance.AccountsPayable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for VendorDebitNote.
/// </summary>
public class VendorDebitNoteConfiguration : BaseEntityConfiguration<VendorDebitNote>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<VendorDebitNote> builder)
    {
        builder.ToTable("VendorDebitNotes");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_VendorDebitNotes_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("char(36)");

        builder.Property(e => e.VendorId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.VendorId)
            .HasDatabaseName("IX_VendorDebitNotes_VendorId");

        builder.Property(e => e.OriginalInvoiceId)
            .HasColumnType("char(36)");

        builder.Property(e => e.DebitNoteNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.DebitNoteNumber })
            .IsUnique()
            .HasDatabaseName("IX_VendorDebitNotes_CompanyId_DebitNoteNumber");

        builder.Property(e => e.DebitNoteDate)
            .HasColumnType("datetime(6)")
            .IsRequired();

        builder.Property(e => e.Reason)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Reference)
            .HasMaxLength(500);

        builder.Property(e => e.CurrencyId)
            .HasColumnType("char(36)")
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

        // RemainingDebit is computed, ignore it
        builder.Ignore(e => e.RemainingDebit);

        builder.Property(e => e.FunctionalAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(VendorDebitNoteStatus.Draft)
            .IsRequired();

        builder.Property(e => e.PostedDate)
            .HasColumnType("datetime(6)");

        builder.Property(e => e.JournalEntryId)
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
            .WithMany(v => v.DebitNotes)
            .HasForeignKey(e => e.VendorId)
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
