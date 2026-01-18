namespace OberstoneERP.Data.PostgreSQL.Finance.AccountsReceivable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for CustomerInvoiceLine.
/// </summary>
public class CustomerInvoiceLineConfiguration : BaseEntityConfiguration<CustomerInvoiceLine>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CustomerInvoiceLine> builder)
    {
        builder.ToTable("CustomerInvoiceLines", "accountsreceivable");

        builder.Property(e => e.CustomerInvoiceId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CustomerInvoiceId)
            .HasDatabaseName("IX_CustomerInvoiceLines_CustomerInvoiceId");

        builder.Property(e => e.LineNumber)
            .IsRequired();

        builder.Property(e => e.ItemCode)
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.RevenueAccountId)
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
        builder.HasOne(e => e.CustomerInvoice)
            .WithMany(ci => ci.Lines)
            .HasForeignKey(e => e.CustomerInvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.RevenueAccount)
            .WithMany()
            .HasForeignKey(e => e.RevenueAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
