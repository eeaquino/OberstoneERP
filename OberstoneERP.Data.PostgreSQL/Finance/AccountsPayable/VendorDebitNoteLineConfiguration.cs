namespace OberstoneERP.Data.PostgreSQL.Finance.AccountsPayable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for VendorDebitNoteLine.
/// </summary>
public class VendorDebitNoteLineConfiguration : BaseEntityConfiguration<VendorDebitNoteLine>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<VendorDebitNoteLine> builder)
    {
        builder.ToTable("VendorDebitNoteLines", "accountspayable");

        builder.Property(e => e.VendorDebitNoteId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.VendorDebitNoteId)
            .HasDatabaseName("IX_VendorDebitNoteLines_VendorDebitNoteId");

        builder.Property(e => e.LineNumber)
            .IsRequired();

        builder.Property(e => e.ItemCode)
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.AccountId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(e => e.Quantity)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(1m)
            .IsRequired();

        builder.Property(e => e.UnitOfMeasure)
            .HasMaxLength(50);

        builder.Property(e => e.UnitPrice)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.NetAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.TaxCodeId)
            .HasColumnType("uuid");

        builder.Property(e => e.TaxAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.TotalAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.VendorDebitNote)
            .WithMany(vdn => vdn.Lines)
            .HasForeignKey(e => e.VendorDebitNoteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Account)
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
