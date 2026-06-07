namespace OberstoneERP.Data.MariaDB.Finance.Taxes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Taxes;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for TaxReturnPeriod.
/// </summary>
public class TaxReturnPeriodConfiguration : BaseEntityConfiguration<TaxReturnPeriod>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<TaxReturnPeriod> builder)
    {
        builder.ToTable("TaxReturnPeriods");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_TaxReturnPeriods_CompanyId");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.TaxAuthority)
            .HasMaxLength(200);

        builder.Property(e => e.ReturnType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.PeriodStartDate)
            .HasColumnType("datetime(6)")
            .IsRequired();

        builder.Property(e => e.PeriodEndDate)
            .HasColumnType("datetime(6)")
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.PeriodStartDate, e.PeriodEndDate })
            .HasDatabaseName("IX_TaxReturnPeriods_CompanyId_Period");

        builder.Property(e => e.DueDate)
            .HasColumnType("datetime(6)")
            .IsRequired();

        builder.Property(e => e.OutputTax)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.InputTax)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        // NetTaxDue is computed, ignore it
        builder.Ignore(e => e.NetTaxDue);

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(TaxReturnStatus.Open)
            .IsRequired();

        builder.Property(e => e.FiledDate)
            .HasColumnType("datetime(6)");

        builder.Property(e => e.FilingReference)
            .HasMaxLength(100);

        builder.Property(e => e.PaymentDate)
            .HasColumnType("datetime(6)");

        builder.Property(e => e.PaymentReference)
            .HasMaxLength(100);

        builder.Property(e => e.Notes)
            .HasMaxLength(1000);

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
