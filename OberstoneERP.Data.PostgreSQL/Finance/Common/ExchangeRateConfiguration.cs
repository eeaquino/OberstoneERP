namespace OberstoneERP.Data.PostgreSQL.Finance.Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Entity configuration for ExchangeRate.
/// </summary>
public class ExchangeRateConfiguration : BaseEntityConfiguration<ExchangeRate>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<ExchangeRate> builder)
    {
        builder.ToTable("ExchangeRates", "common");

        builder.Property(e => e.FromCurrencyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(e => e.ToCurrencyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(e => e.EffectiveDate)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        // Composite index for efficient rate lookups
        builder.HasIndex(e => new { e.TenantId, e.FromCurrencyId, e.ToCurrencyId, e.EffectiveDate })
            .HasDatabaseName("IX_ExchangeRates_Lookup");

        builder.Property(e => e.Rate)
            .HasColumnType("decimal(19,8)")
            .IsRequired();

        builder.Property(e => e.RateType)
            .HasConversion<int>()
            .HasDefaultValue(ExchangeRateType.Standard)
            .IsRequired();

        builder.Property(e => e.Source)
            .HasMaxLength(100);

        // Navigation properties
        builder.HasOne(e => e.FromCurrency)
            .WithMany(c => c.ExchangeRatesFrom)
            .HasForeignKey(e => e.FromCurrencyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ToCurrency)
            .WithMany(c => c.ExchangeRatesTo)
            .HasForeignKey(e => e.ToCurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
