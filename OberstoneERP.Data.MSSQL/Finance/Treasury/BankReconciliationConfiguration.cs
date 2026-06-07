namespace OberstoneERP.Data.MSSQL.Finance.Treasury;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Treasury;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for BankReconciliation.
/// </summary>
public class BankReconciliationConfiguration : BaseEntityConfiguration<BankReconciliation>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<BankReconciliation> builder)
    {
        builder.ToTable("BankReconciliations", "treasury");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_BankReconciliations_CompanyId");

        builder.Property(e => e.BankAccountId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.BankAccountId)
            .HasDatabaseName("IX_BankReconciliations_BankAccountId");

        builder.Property(e => e.StatementDate)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.HasIndex(e => new { e.BankAccountId, e.StatementDate })
            .HasDatabaseName("IX_BankReconciliations_BankAccountId_StatementDate");

        builder.Property(e => e.StatementNumber)
            .HasMaxLength(100);

        builder.Property(e => e.StatementBeginningBalance)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.StatementEndingBalance)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.BookBeginningBalance)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.BookEndingBalance)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.ClearedDeposits)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.ClearedWithdrawals)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.DepositsInTransit)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.OutstandingChecks)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Difference)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(ReconciliationStatus.InProgress)
            .IsRequired();

        builder.Property(e => e.CompletedDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.CompletedBy)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.Notes)
            .HasMaxLength(1000);

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.BankAccount)
            .WithMany(ba => ba.Reconciliations)
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
