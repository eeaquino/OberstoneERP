namespace OberstoneERP.Data.PostgreSQL.Finance.Treasury;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Treasury;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for BankTransaction.
/// </summary>
public class BankTransactionConfiguration : BaseEntityConfiguration<BankTransaction>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<BankTransaction> builder)
    {
        builder.ToTable("BankTransactions", "treasury");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_BankTransactions_CompanyId");

        builder.Property(e => e.BankAccountId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.BankAccountId)
            .HasDatabaseName("IX_BankTransactions_BankAccountId");

        builder.Property(e => e.TransactionNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.TransactionNumber })
            .IsUnique()
            .HasDatabaseName("IX_BankTransactions_CompanyId_TransactionNumber");

        builder.Property(e => e.TransactionDate)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.HasIndex(e => new { e.BankAccountId, e.TransactionDate })
            .HasDatabaseName("IX_BankTransactions_BankAccountId_TransactionDate");

        builder.Property(e => e.ValueDate)
            .HasColumnType("timestamp with time zone");

        builder.Property(e => e.TransactionType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Reference)
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.PayeePayer)
            .HasMaxLength(200);

        builder.Property(e => e.DepositAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.WithdrawalAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        // NetAmount is computed, ignore it
        builder.Ignore(e => e.NetAmount);

        builder.Property(e => e.RunningBalance)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(BankTransactionStatus.Unreconciled)
            .IsRequired();

        builder.Property(e => e.BankStatementId)
            .HasColumnType("uuid");

        builder.Property(e => e.StatementLineNumber);

        builder.Property(e => e.BankReconciliationId)
            .HasColumnType("uuid");

        builder.Property(e => e.SourceDocumentType)
            .HasConversion<int?>();

        builder.Property(e => e.SourceDocumentId)
            .HasColumnType("uuid");

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.BankAccount)
            .WithMany(ba => ba.Transactions)
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.BankReconciliation)
            .WithMany(br => br.ReconciledTransactions)
            .HasForeignKey(e => e.BankReconciliationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
