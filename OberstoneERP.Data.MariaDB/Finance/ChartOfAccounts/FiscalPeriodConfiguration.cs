namespace OberstoneERP.Data.MariaDB.Finance.ChartOfAccounts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for FiscalPeriod.
/// </summary>
public class FiscalPeriodConfiguration : BaseEntityConfiguration<FiscalPeriod>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<FiscalPeriod> builder)
    {
        builder.ToTable("FiscalPeriods");

        builder.Property(e => e.FiscalYearId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.FiscalYearId)
            .HasDatabaseName("IX_FiscalPeriods_FiscalYearId");

        builder.Property(e => e.PeriodNumber)
            .IsRequired();

        builder.HasIndex(e => new { e.FiscalYearId, e.PeriodNumber })
            .IsUnique()
            .HasDatabaseName("IX_FiscalPeriods_FiscalYearId_PeriodNumber");

        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.StartDate)
            .HasColumnType("datetime(6)")
            .IsRequired();

        builder.Property(e => e.EndDate)
            .HasColumnType("datetime(6)")
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(FiscalPeriodStatus.Open)
            .IsRequired();

        builder.Property(e => e.IsAdjustmentPeriod)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.ClosingDate)
            .HasColumnType("datetime(6)");

        builder.Property(e => e.ClosedBy)
            .HasColumnType("char(36)");

        // Navigation properties
        builder.HasOne(e => e.FiscalYear)
            .WithMany(fy => fy.FiscalPeriods)
            .HasForeignKey(e => e.FiscalYearId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
