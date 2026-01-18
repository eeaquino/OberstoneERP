namespace OberstoneERP.Data.PostgreSQL.Finance.ChartOfAccounts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for FiscalPeriod.
/// </summary>
public class FiscalPeriodConfiguration : BaseEntityConfiguration<FiscalPeriod>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<FiscalPeriod> builder)
    {
        builder.ToTable("FiscalPeriods", "chartofaccounts");

        builder.Property(e => e.FiscalYearId)
            .HasColumnType("uuid")
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
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(e => e.EndDate)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(FiscalPeriodStatus.Open)
            .IsRequired();

        builder.Property(e => e.IsAdjustmentPeriod)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.ClosingDate)
            .HasColumnType("timestamp with time zone");

        builder.Property(e => e.ClosedBy)
            .HasColumnType("uuid");

        // Navigation properties
        builder.HasOne(e => e.FiscalYear)
            .WithMany(fy => fy.FiscalPeriods)
            .HasForeignKey(e => e.FiscalYearId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
