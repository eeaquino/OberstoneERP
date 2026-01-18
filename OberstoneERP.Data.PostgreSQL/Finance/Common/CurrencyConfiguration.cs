namespace OberstoneERP.Data.PostgreSQL.Finance.Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Entity configuration for Currency.
/// </summary>
public class CurrencyConfiguration : BaseEntityConfiguration<Currency>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("Currencies", "common");

        builder.Property(e => e.Code)
            .HasMaxLength(3)
            .IsRequired();

        builder.HasIndex(e => new { e.TenantId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_Currencies_TenantId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Symbol)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.DecimalPlaces)
            .HasDefaultValue(2)
            .IsRequired();

        builder.Property(e => e.SymbolBefore)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.DecimalSeparator)
            .HasMaxLength(5)
            .HasDefaultValue(".")
            .IsRequired();

        builder.Property(e => e.ThousandsSeparator)
            .HasMaxLength(5)
            .HasDefaultValue(",")
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();
    }
}
