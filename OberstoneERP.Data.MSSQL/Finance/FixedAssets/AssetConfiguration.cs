namespace OberstoneERP.Data.MSSQL.Finance.FixedAssets;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.FixedAssets;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for Asset.
/// </summary>
public class AssetConfiguration : BaseEntityConfiguration<Asset>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<Asset> builder)
    {
        builder.ToTable("Assets", "fixedassets");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_Assets_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.AssetCategoryId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.AssetCategoryId)
            .HasDatabaseName("IX_Assets_AssetCategoryId");

        builder.Property(e => e.AssetNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.AssetNumber })
            .IsUnique()
            .HasDatabaseName("IX_Assets_CompanyId_AssetNumber");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.SerialNumber)
            .HasMaxLength(100);

        builder.Property(e => e.ModelNumber)
            .HasMaxLength(100);

        builder.Property(e => e.Manufacturer)
            .HasMaxLength(200);

        builder.Property(e => e.Location)
            .HasMaxLength(200);

        builder.Property(e => e.CostCenterId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.AcquisitionDate)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(e => e.InServiceDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.AcquisitionCost)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.BookValue)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.SalvageValue)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.AccumulatedDepreciation)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.UsefulLifeMonths)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.RemainingLifeMonths)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.DepreciationMethodId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.MonthlyDepreciation)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(AssetStatus.Active)
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

        builder.HasOne(e => e.AssetCategory)
            .WithMany(ac => ac.Assets)
            .HasForeignKey(e => e.AssetCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.DepreciationMethod)
            .WithMany()
            .HasForeignKey(e => e.DepreciationMethodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
