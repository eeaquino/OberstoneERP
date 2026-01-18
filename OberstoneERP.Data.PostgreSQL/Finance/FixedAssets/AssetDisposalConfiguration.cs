namespace OberstoneERP.Data.PostgreSQL.Finance.FixedAssets;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.FixedAssets;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for AssetDisposal.
/// </summary>
public class AssetDisposalConfiguration : BaseEntityConfiguration<AssetDisposal>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<AssetDisposal> builder)
    {
        builder.ToTable("AssetDisposals", "fixedassets");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_AssetDisposals_CompanyId");

        builder.Property(e => e.AssetId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.AssetId)
            .HasDatabaseName("IX_AssetDisposals_AssetId");

        builder.Property(e => e.DisposalNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.DisposalNumber })
            .IsUnique()
            .HasDatabaseName("IX_AssetDisposals_CompanyId_DisposalNumber");

        builder.Property(e => e.DisposalDate)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(e => e.DisposalType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.DisposalReason)
            .HasMaxLength(500);

        builder.Property(e => e.OriginalCost)
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

        builder.Property(e => e.DisposalProceeds)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.DisposalCosts)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        // NetProceeds is computed, ignore it
        builder.Ignore(e => e.NetProceeds);

        builder.Property(e => e.GainLoss)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.CustomerId)
            .HasColumnType("uuid");

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(DisposalStatus.Draft)
            .IsRequired();

        builder.Property(e => e.JournalEntryId)
            .HasColumnType("uuid");

        builder.Property(e => e.ApprovedBy)
            .HasColumnType("uuid");

        builder.Property(e => e.ApprovedAt)
            .HasColumnType("timestamp with time zone");

                // Navigation properties
                builder.HasOne(e => e.Company)
                    .WithMany()
                    .HasForeignKey(e => e.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(e => e.Asset)
                    .WithMany(a => a.Disposals)
                    .HasForeignKey(e => e.AssetId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
