namespace OberstoneERP.Data.MariaDB.Finance.Controlling;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Controlling;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for ItemCostHistory.
/// </summary>
public class ItemCostHistoryConfiguration : BaseEntityConfiguration<ItemCostHistory>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<ItemCostHistory> builder)
    {
        builder.ToTable("ItemCostHistories");

        builder.Property(e => e.ItemCostId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.ItemCostId)
            .HasDatabaseName("IX_ItemCostHistories_ItemCostId");

        builder.Property(e => e.ChangeDate)
            .HasColumnType("datetime(6)")
            .IsRequired();

        builder.HasIndex(e => new { e.ItemCostId, e.ChangeDate })
            .HasDatabaseName("IX_ItemCostHistories_ItemCostId_ChangeDate");

        builder.Property(e => e.ChangeType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.ChangeReason)
            .HasMaxLength(500);

        builder.Property(e => e.PreviousStandardCost)
            .HasColumnType("decimal(19,6)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.NewStandardCost)
            .HasColumnType("decimal(19,6)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.PreviousAverageCost)
            .HasColumnType("decimal(19,6)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.NewAverageCost)
            .HasColumnType("decimal(19,6)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.QuantityOnHand)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.RevaluationAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.SourceType)
            .HasConversion<int?>();

        builder.Property(e => e.SourceDocumentId)
            .HasColumnType("char(36)");

        builder.Property(e => e.SourceDocumentNumber)
            .HasMaxLength(100);

        builder.Property(e => e.JournalEntryId)
            .HasColumnType("char(36)");

        // Navigation properties
        builder.HasOne(e => e.ItemCost)
            .WithMany(ic => ic.CostHistory)
            .HasForeignKey(e => e.ItemCostId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
