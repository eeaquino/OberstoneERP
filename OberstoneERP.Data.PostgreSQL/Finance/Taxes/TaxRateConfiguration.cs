namespace OberstoneERP.Data.PostgreSQL.Finance.Taxes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Taxes;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for TaxRate.
/// </summary>
public class TaxRateConfiguration : BaseEntityConfiguration<TaxRate>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<TaxRate> builder)
    {
        builder.ToTable("TaxRates", "taxes");

        builder.Property(e => e.TaxCodeId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.TaxCodeId)
            .HasDatabaseName("IX_TaxRates_TaxCodeId");

        builder.Property(e => e.EffectiveFrom)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        // Index for efficient rate lookup by date
        builder.HasIndex(e => new { e.TaxCodeId, e.EffectiveFrom })
            .HasDatabaseName("IX_TaxRates_TaxCodeId_EffectiveFrom");

        builder.Property(e => e.EffectiveTo)
            .HasColumnType("timestamp with time zone");

        builder.Property(e => e.Rate)
            .HasColumnType("decimal(7,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.MinimumAmount)
            .HasColumnType("decimal(19,4)");

        builder.Property(e => e.MaximumAmount)
            .HasColumnType("decimal(19,4)");

        builder.Property(e => e.FixedAmount)
            .HasColumnType("decimal(19,4)");

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.TaxCode)
            .WithMany(tc => tc.TaxRates)
            .HasForeignKey(e => e.TaxCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
