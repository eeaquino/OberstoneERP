namespace OberstoneERP.Data.MSSQL.Finance.Treasury;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Treasury;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for CashFlowForecast.
/// </summary>
public class CashFlowForecastConfiguration : BaseEntityConfiguration<CashFlowForecast>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CashFlowForecast> builder)
    {
        builder.ToTable("CashFlowForecasts", "treasury");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_CashFlowForecasts_CompanyId");

        builder.Property(e => e.BankAccountId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.CashFlowCategoryId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CashFlowCategoryId)
            .HasDatabaseName("IX_CashFlowForecasts_CashFlowCategoryId");

        builder.Property(e => e.CurrencyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.ForecastDate)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.ForecastDate })
            .HasDatabaseName("IX_CashFlowForecasts_CompanyId_ForecastDate");

        builder.Property(e => e.PeriodEndDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.ForecastType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.Reference)
            .HasMaxLength(100);

        builder.Property(e => e.InflowAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.OutflowAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        // NetAmount and WeightedAmount are computed, ignore them
        builder.Ignore(e => e.NetAmount);
        builder.Ignore(e => e.WeightedAmount);

        builder.Property(e => e.Probability)
            .HasColumnType("decimal(5,2)")
            .HasDefaultValue(100m)
            .IsRequired();

        builder.Property(e => e.Source)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.SourceDocumentId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(CashFlowForecastStatus.Active)
            .IsRequired();

        builder.Property(e => e.ActualAmount)
            .HasColumnType("decimal(19,4)");

        builder.Property(e => e.RealizedDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.Notes)
            .HasMaxLength(1000);

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.BankAccount)
            .WithMany()
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.CashFlowCategory)
            .WithMany(cfc => cfc.Forecasts)
            .HasForeignKey(e => e.CashFlowCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
