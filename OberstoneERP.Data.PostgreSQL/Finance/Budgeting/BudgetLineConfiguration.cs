namespace OberstoneERP.Data.PostgreSQL.Finance.Budgeting;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Budgeting;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for BudgetLine.
/// </summary>
public class BudgetLineConfiguration : BaseEntityConfiguration<BudgetLine>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<BudgetLine> builder)
    {
        builder.ToTable("BudgetLines", "budgeting");

        builder.Property(e => e.BudgetId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.BudgetId)
            .HasDatabaseName("IX_BudgetLines_BudgetId");

        builder.Property(e => e.FiscalPeriodId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.FiscalPeriodId)
            .HasDatabaseName("IX_BudgetLines_FiscalPeriodId");

        // Unique constraint - one budget line per budget per fiscal period
        builder.HasIndex(e => new { e.BudgetId, e.FiscalPeriodId })
            .IsUnique()
            .HasDatabaseName("IX_BudgetLines_BudgetId_FiscalPeriodId");

        builder.Property(e => e.Amount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Notes)
            .HasMaxLength(500);

        // Navigation properties
        builder.HasOne(e => e.Budget)
            .WithMany(b => b.Lines)
            .HasForeignKey(e => e.BudgetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.FiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.FiscalPeriodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
