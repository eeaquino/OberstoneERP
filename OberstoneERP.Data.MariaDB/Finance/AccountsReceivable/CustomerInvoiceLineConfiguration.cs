namespace OberstoneERP.Data.MariaDB.Finance.AccountsReceivable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for CustomerInvoiceLine.
/// </summary>
public class CustomerInvoiceLineConfiguration : BaseEntityConfiguration<CustomerInvoiceLine>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CustomerInvoiceLine> builder)
    {
        builder.ToTable("CustomerInvoiceLines");

        builder.Property(e => e.CustomerInvoiceId).HasColumnType("char(36)").IsRequired();
        builder.HasIndex(e => e.CustomerInvoiceId).HasDatabaseName("IX_CustomerInvoiceLines_CustomerInvoiceId");
        builder.Property(e => e.LineNumber).IsRequired();
        builder.Property(e => e.ItemCode).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(500).IsRequired();
        builder.Property(e => e.RevenueAccountId).HasColumnType("char(36)").IsRequired();
        builder.Property(e => e.Quantity).HasColumnType("decimal(19,4)").HasDefaultValue(1m).IsRequired();
        builder.Property(e => e.UnitOfMeasure).HasMaxLength(50);
        builder.Property(e => e.UnitPrice).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.DiscountPercent).HasColumnType("decimal(5,2)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.DiscountAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.NetAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.TaxCodeId).HasColumnType("char(36)");
        builder.Property(e => e.TaxAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.TotalAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();

        builder.HasOne(e => e.CustomerInvoice).WithMany(ci => ci.Lines).HasForeignKey(e => e.CustomerInvoiceId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.RevenueAccount).WithMany().HasForeignKey(e => e.RevenueAccountId).OnDelete(DeleteBehavior.Restrict);
    }
}
