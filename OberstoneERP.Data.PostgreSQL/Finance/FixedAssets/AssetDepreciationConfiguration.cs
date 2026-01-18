namespace OberstoneERP.Data.PostgreSQL.Finance.FixedAssets;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.FixedAssets;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for AssetDepreciation.
/// </summary>
public class AssetDepreciationConfiguration : BaseEntityConfiguration<AssetDepreciation>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<AssetDepreciation> builder)
    {
        builder.ToTable("AssetDepreciations", "fixedassets");

        builder.Property(e => e.AssetId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.AssetId)
            .HasDatabaseName("IX_AssetDepreciations_AssetId");

        builder.Property(e => e.FiscalPeriodId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.FiscalPeriodId)
            .HasDatabaseName("IX_AssetDepreciations_FiscalPeriodId");

        // Unique index to prevent duplicate depreciation entries for the same asset in the same period
        builder.HasIndex(e => new { e.AssetId, e.FiscalPeriodId })
            .IsUnique()
            .HasDatabaseName("IX_AssetDepreciations_AssetId_FiscalPeriodId");

        builder.Property(e => e.DepreciationDate)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(e => e.DepreciationAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.AccumulatedDepreciation)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.BookValue)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.EntryType)
            .HasConversion<int>()
            .HasDefaultValue(DepreciationEntryType.Normal)
            .IsRequired();

                builder.Property(e => e.Status)
                    .HasConversion<int>()
                    .HasDefaultValue(DepreciationStatus.Calculated)
                    .IsRequired();

                builder.Property(e => e.JournalEntryId)
                    .HasColumnType("uuid");

                builder.Property(e => e.Notes)
                    .HasMaxLength(500);

                // Navigation properties
                builder.HasOne(e => e.Asset)
                    .WithMany(a => a.DepreciationHistory)
                    .HasForeignKey(e => e.AssetId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(e => e.FiscalPeriod)
                    .WithMany()
                    .HasForeignKey(e => e.FiscalPeriodId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
