namespace OberstoneERP.Data.MSSQL.Finance.AccountsPayable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for VendorInvoice.
/// </summary>
public class VendorInvoiceConfiguration : BaseEntityConfiguration<VendorInvoice>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<VendorInvoice> builder)
    {
        builder.ToTable("VendorInvoices", "accountspayable");

        builder.Property(e => e.CompanyId).HasColumnType("uniqueidentifier").IsRequired();
        builder.HasIndex(e => e.CompanyId).HasDatabaseName("IX_VendorInvoices_CompanyId");
        builder.Property(e => e.SiteId).HasColumnType("uniqueidentifier");
        builder.Property(e => e.VendorId).HasColumnType("uniqueidentifier").IsRequired();
        builder.HasIndex(e => e.VendorId).HasDatabaseName("IX_VendorInvoices_VendorId");
        builder.Property(e => e.InvoiceNumber).HasMaxLength(50).IsRequired();
        builder.HasIndex(e => new { e.CompanyId, e.InvoiceNumber }).IsUnique().HasDatabaseName("IX_VendorInvoices_CompanyId_InvoiceNumber");
        builder.Property(e => e.VendorInvoiceNumber).HasMaxLength(100).IsRequired();
        builder.HasIndex(e => new { e.VendorId, e.VendorInvoiceNumber }).HasDatabaseName("IX_VendorInvoices_VendorId_VendorInvoiceNumber");
        builder.Property(e => e.InvoiceDate).HasColumnType("datetime2").IsRequired();
        builder.Property(e => e.ReceivedDate).HasColumnType("datetime2").IsRequired();
        builder.Property(e => e.DueDate).HasColumnType("datetime2").IsRequired();
        builder.HasIndex(e => new { e.CompanyId, e.DueDate }).HasDatabaseName("IX_VendorInvoices_CompanyId_DueDate");
        builder.Property(e => e.PaymentTermsId).HasColumnType("uniqueidentifier");
        builder.Property(e => e.PurchaseOrderNumber).HasMaxLength(100);
        builder.Property(e => e.Reference).HasMaxLength(500);
        builder.Property(e => e.CurrencyId).HasColumnType("uniqueidentifier").IsRequired();
        builder.Property(e => e.ExchangeRate).HasColumnType("decimal(19,8)").HasDefaultValue(1m).IsRequired();
        builder.Property(e => e.Subtotal).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.DiscountAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.TaxAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.WithholdingTaxAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.TotalAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.PaidAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Ignore(e => e.BalanceDue);
        builder.Property(e => e.FunctionalAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.Status).HasConversion<int>().HasDefaultValue(VendorInvoiceStatus.Draft).IsRequired();
        builder.Property(e => e.PostedDate).HasColumnType("datetime2");
        builder.Property(e => e.JournalEntryId).HasColumnType("uniqueidentifier");

        builder.HasOne(e => e.Company).WithMany().HasForeignKey(e => e.CompanyId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Site).WithMany().HasForeignKey(e => e.SiteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Vendor).WithMany(v => v.Invoices).HasForeignKey(e => e.VendorId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.PaymentTerms).WithMany().HasForeignKey(e => e.PaymentTermsId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Currency).WithMany().HasForeignKey(e => e.CurrencyId).OnDelete(DeleteBehavior.Restrict);
    }
}
