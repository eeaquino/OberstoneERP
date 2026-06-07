namespace OberstoneERP.Data.MSSQL.Finance.Budgeting;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Budgeting;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for BudgetTransfer.
/// </summary>
public class BudgetTransferConfiguration : BaseEntityConfiguration<BudgetTransfer>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<BudgetTransfer> builder)
    {
        builder.ToTable("BudgetTransfers", "budgeting");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_BudgetTransfers_CompanyId");

        builder.Property(e => e.BudgetVersionId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.BudgetVersionId)
            .HasDatabaseName("IX_BudgetTransfers_BudgetVersionId");

        builder.Property(e => e.TransferNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.TransferNumber })
            .IsUnique()
            .HasDatabaseName("IX_BudgetTransfers_CompanyId_TransferNumber");

        builder.Property(e => e.TransferDate)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.FromAccountId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.FromCostCenterId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.FromFiscalPeriodId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.ToAccountId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.ToCostCenterId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.ToFiscalPeriodId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.Amount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(BudgetTransferStatus.Draft)
            .IsRequired();

        builder.Property(e => e.ApprovedBy)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.ApprovedAt)
            .HasColumnType("datetime2");

        builder.Property(e => e.Notes)
            .HasMaxLength(1000);

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.BudgetVersion)
            .WithMany()
            .HasForeignKey(e => e.BudgetVersionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FromAccount)
            .WithMany()
            .HasForeignKey(e => e.FromAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FromCostCenter)
            .WithMany()
            .HasForeignKey(e => e.FromCostCenterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FromFiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.FromFiscalPeriodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ToAccount)
            .WithMany()
            .HasForeignKey(e => e.ToAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ToCostCenter)
            .WithMany()
            .HasForeignKey(e => e.ToCostCenterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ToFiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.ToFiscalPeriodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
