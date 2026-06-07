namespace OberstoneERP.Data.MariaDB.Finance.Intercompany;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Intercompany;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for IntercompanyTransaction.
/// </summary>
public class IntercompanyTransactionConfiguration : BaseEntityConfiguration<IntercompanyTransaction>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<IntercompanyTransaction> builder)
    {
        builder.ToTable("IntercompanyTransactions");

        builder.Property(e => e.IntercompanyAgreementId)
            .HasColumnType("char(36)");

        builder.Property(e => e.SourceCompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.SourceCompanyId)
            .HasDatabaseName("IX_IntercompanyTransactions_SourceCompanyId");

        builder.Property(e => e.TargetCompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.TargetCompanyId)
            .HasDatabaseName("IX_IntercompanyTransactions_TargetCompanyId");

        builder.Property(e => e.TransactionNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.TenantId, e.TransactionNumber })
            .IsUnique()
            .HasDatabaseName("IX_IntercompanyTransactions_TenantId_TransactionNumber");

        builder.Property(e => e.TransactionDate)
            .HasColumnType("datetime(6)")
            .IsRequired();

        builder.HasIndex(e => new { e.SourceCompanyId, e.TransactionDate })
            .HasDatabaseName("IX_IntercompanyTransactions_SourceCompanyId_TransactionDate");

        builder.Property(e => e.TransactionType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.Reference)
            .HasMaxLength(100);

        builder.Property(e => e.CurrencyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.Amount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.ExchangeRate)
            .HasColumnType("decimal(19,8)")
            .HasDefaultValue(1m)
            .IsRequired();

        builder.Property(e => e.SourceFunctionalAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.TargetFunctionalAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(IntercompanyTransactionStatus.Draft)
            .IsRequired();

        builder.Property(e => e.SourceJournalEntryId)
            .HasColumnType("char(36)");

        builder.Property(e => e.TargetJournalEntryId)
            .HasColumnType("char(36)");

        builder.Property(e => e.SourceFiscalPeriodId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.TargetFiscalPeriodId)
            .HasColumnType("char(36)")
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.IntercompanyAgreement)
            .WithMany(ia => ia.Transactions)
            .HasForeignKey(e => e.IntercompanyAgreementId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.SourceCompany)
            .WithMany()
            .HasForeignKey(e => e.SourceCompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TargetCompany)
            .WithMany()
            .HasForeignKey(e => e.TargetCompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.SourceFiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.SourceFiscalPeriodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TargetFiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.TargetFiscalPeriodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
