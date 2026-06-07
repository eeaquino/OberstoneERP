namespace OberstoneERP.Data.MariaDB.Finance.AccountsReceivable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for PaymentTerms.
/// </summary>
public class PaymentTermsConfiguration : BaseEntityConfiguration<PaymentTerms>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<PaymentTerms> builder)
    {
        builder.ToTable("PaymentTerms");

        builder.Property(e => e.CompanyId).HasColumnType("char(36)").IsRequired();
        builder.HasIndex(e => e.CompanyId).HasDatabaseName("IX_PaymentTerms_CompanyId");
        builder.Property(e => e.Code).HasMaxLength(50).IsRequired();
        builder.HasIndex(e => new { e.CompanyId, e.Code }).IsUnique().HasDatabaseName("IX_PaymentTerms_CompanyId_Code");
        builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.DueDays).HasDefaultValue(0).IsRequired();
        builder.Property(e => e.DueDateMethod).HasConversion<int>().HasDefaultValue(DueDateMethod.FromInvoiceDate).IsRequired();
        builder.Property(e => e.DueDayOfMonth);
        builder.Property(e => e.DiscountPercent).HasColumnType("decimal(5,2)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.DiscountDays).HasDefaultValue(0).IsRequired();
        builder.Property(e => e.IsActive).HasDefaultValue(true).IsRequired();

        builder.HasOne(e => e.Company).WithMany().HasForeignKey(e => e.CompanyId).OnDelete(DeleteBehavior.Restrict);
    }
}
