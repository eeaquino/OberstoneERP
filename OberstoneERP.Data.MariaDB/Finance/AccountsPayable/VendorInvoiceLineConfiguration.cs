namespace OberstoneERP.Data.MariaDB.Finance.AccountsPayable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for VendorInvoiceLine.
/// </summary>
public class VendorInvoiceLineConfiguration : BaseEntityConfiguration<VendorInvoiceLine>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<VendorInvoiceLine> builder)
    {
        builder.ToTable("VendorInvoiceLines");

        builder.Property(e => e.VendorInvoiceId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.VendorInvoiceId)
            .HasDatabaseName("IX_VendorInvoiceLines_VendorInvoiceId");

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

        builder.Property(e => e.DiscountPercent)
            .HasColumnType("decimal(5,2)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.DiscountAmount)
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
        builder.HasOne(e => e.VendorInvoice)
            .WithMany(vi => vi.Lines)
            .HasForeignKey(e => e.VendorInvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Account)
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
