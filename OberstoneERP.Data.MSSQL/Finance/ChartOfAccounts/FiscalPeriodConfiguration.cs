namespace OberstoneERP.Data.MSSQL.Finance.ChartOfAccounts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.MSSQL.Finance.Common;

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
            .HasColumnType("uniqueidentifier")
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
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(e => e.EndDate)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(FiscalPeriodStatus.Open)
            .IsRequired();

        builder.Property(e => e.IsAdjustmentPeriod)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.ClosingDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.ClosedBy)
            .HasColumnType("uniqueidentifier");

        // Navigation properties
        builder.HasOne(e => e.FiscalYear)
            .WithMany(fy => fy.FiscalPeriods)
            .HasForeignKey(e => e.FiscalYearId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
