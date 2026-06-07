namespace OberstoneERP.Data.MSSQL.Finance.Controlling;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Controlling;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for ItemCost.
/// </summary>
public class ItemCostConfiguration : BaseEntityConfiguration<ItemCost>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<ItemCost> builder)
    {
        builder.ToTable("ItemCosts", "controlling");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_ItemCosts_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.ItemCode)
            .HasMaxLength(50)
            .IsRequired();

        // Unique index for item cost per company and site combination
        builder.HasIndex(e => new { e.CompanyId, e.SiteId, e.ItemCode })
            .IsUnique()
            .HasDatabaseName("IX_ItemCosts_CompanyId_SiteId_ItemCode");

        builder.Property(e => e.ItemDescription)
            .HasMaxLength(200);

        builder.Property(e => e.CostingMethod)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.CurrencyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.StandardCost)
            .HasColumnType("decimal(19,6)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.PendingStandardCost)
            .HasColumnType("decimal(19,6)");

        builder.Property(e => e.PendingStandardCostEffectiveDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.AverageCost)
            .HasColumnType("decimal(19,6)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.LastPurchasePrice)
            .HasColumnType("decimal(19,6)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.LastPurchaseDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.QuantityOnHand)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.TotalInventoryValue)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Site)
            .WithMany()
            .HasForeignKey(e => e.SiteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
