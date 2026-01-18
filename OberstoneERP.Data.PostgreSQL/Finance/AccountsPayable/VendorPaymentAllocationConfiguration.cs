namespace OberstoneERP.Data.PostgreSQL.Finance.AccountsPayable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for VendorPaymentAllocation.
/// </summary>
public class VendorPaymentAllocationConfiguration : BaseEntityConfiguration<VendorPaymentAllocation>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<VendorPaymentAllocation> builder)
    {
        builder.ToTable("VendorPaymentAllocations", "accountspayable");

        builder.Property(e => e.VendorPaymentId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.VendorPaymentId)
            .HasDatabaseName("IX_VendorPaymentAllocations_VendorPaymentId");

        builder.Property(e => e.VendorInvoiceId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.VendorInvoiceId)
            .HasDatabaseName("IX_VendorPaymentAllocations_VendorInvoiceId");

        builder.Property(e => e.Amount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.DiscountTaken)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.WithholdingTax)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.ExchangeGainLoss)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.VendorPayment)
            .WithMany(vp => vp.Allocations)
            .HasForeignKey(e => e.VendorPaymentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.VendorInvoice)
            .WithMany(vi => vi.PaymentAllocations)
            .HasForeignKey(e => e.VendorInvoiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
