namespace OberstoneERP.Data.PostgreSQL.Finance.Budgeting;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Budgeting;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for Budget.
/// </summary>
public class BudgetConfiguration : BaseEntityConfiguration<Budget>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable("Budgets", "budgeting");

        builder.Property(e => e.BudgetVersionId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.BudgetVersionId)
            .HasDatabaseName("IX_Budgets_BudgetVersionId");

        builder.Property(e => e.AccountId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.AccountId)
            .HasDatabaseName("IX_Budgets_AccountId");

        builder.Property(e => e.CostCenterId)
            .HasColumnType("uuid");

        builder.Property(e => e.ProfitCenterId)
            .HasColumnType("uuid");

        builder.Property(e => e.SiteId)
            .HasColumnType("uuid");

        // Unique constraint for budget entry combination
        builder.HasIndex(e => new { e.BudgetVersionId, e.AccountId, e.CostCenterId, e.ProfitCenterId, e.SiteId })
            .IsUnique()
            .HasDatabaseName("IX_Budgets_Combination");

        builder.Property(e => e.AnnualAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Notes)
            .HasMaxLength(500);

        // Navigation properties
        builder.HasOne(e => e.BudgetVersion)
            .WithMany(bv => bv.Budgets)
            .HasForeignKey(e => e.BudgetVersionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Account)
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.CostCenter)
            .WithMany()
            .HasForeignKey(e => e.CostCenterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ProfitCenter)
            .WithMany()
            .HasForeignKey(e => e.ProfitCenterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Site)
            .WithMany()
            .HasForeignKey(e => e.SiteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
