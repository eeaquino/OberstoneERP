namespace OberstoneERP.Data.MariaDB.Finance.AccountsPayable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for VendorDebitNoteLine.
/// </summary>
public class VendorDebitNoteLineConfiguration : BaseEntityConfiguration<VendorDebitNoteLine>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<VendorDebitNoteLine> builder)
    {
        builder.ToTable("VendorDebitNoteLines");

        builder.Property(e => e.VendorDebitNoteId)
            .HasColumnType("char(36)")
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
            .HasColumnType("char(36)")
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
            .HasColumnType("char(36)");

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
