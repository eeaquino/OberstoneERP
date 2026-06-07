namespace OberstoneERP.Data.MariaDB.Finance.AccountsReceivable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for CustomerPaymentAllocation.
/// </summary>
public class CustomerPaymentAllocationConfiguration : BaseEntityConfiguration<CustomerPaymentAllocation>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CustomerPaymentAllocation> builder)
    {
        builder.ToTable("CustomerPaymentAllocations");

        builder.Property(e => e.CustomerPaymentId).HasColumnType("char(36)").IsRequired();
        builder.HasIndex(e => e.CustomerPaymentId).HasDatabaseName("IX_CustomerPaymentAllocations_CustomerPaymentId");
        builder.Property(e => e.CustomerInvoiceId).HasColumnType("char(36)").IsRequired();
        builder.HasIndex(e => e.CustomerInvoiceId).HasDatabaseName("IX_CustomerPaymentAllocations_CustomerInvoiceId");
        builder.Property(e => e.Amount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.DiscountTaken).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.WriteOffAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.ExchangeGainLoss).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();

        builder.HasOne(e => e.CustomerPayment).WithMany(cp => cp.Allocations).HasForeignKey(e => e.CustomerPaymentId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.CustomerInvoice).WithMany(ci => ci.PaymentAllocations).HasForeignKey(e => e.CustomerInvoiceId).OnDelete(DeleteBehavior.Restrict);
    }
}
