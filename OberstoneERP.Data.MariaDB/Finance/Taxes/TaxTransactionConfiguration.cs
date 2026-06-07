namespace OberstoneERP.Data.MariaDB.Finance.Taxes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Taxes;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for TaxTransaction.
/// </summary>
public class TaxTransactionConfiguration : BaseEntityConfiguration<TaxTransaction>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<TaxTransaction> builder)
    {
        builder.ToTable("TaxTransactions");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_TaxTransactions_CompanyId");

        builder.Property(e => e.TaxCodeId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.TaxCodeId)
            .HasDatabaseName("IX_TaxTransactions_TaxCodeId");

        builder.Property(e => e.TaxRateId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.SourceDocumentType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.SourceDocumentId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => new { e.SourceDocumentType, e.SourceDocumentId })
            .HasDatabaseName("IX_TaxTransactions_SourceDocument");

        builder.Property(e => e.SourceDocumentLineId)
            .HasColumnType("char(36)");

        builder.Property(e => e.SourceDocumentNumber)
            .HasMaxLength(100);

        builder.Property(e => e.TransactionDate)
            .HasColumnType("datetime(6)")
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.TransactionDate })
            .HasDatabaseName("IX_TaxTransactions_CompanyId_TransactionDate");

        builder.Property(e => e.FiscalPeriodId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.FiscalPeriodId)
            .HasDatabaseName("IX_TaxTransactions_FiscalPeriodId");

        builder.Property(e => e.Direction)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.TaxableAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.TaxRatePercent)
            .HasColumnType("decimal(7,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.TaxAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.RecoverableAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.NonRecoverableAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.CurrencyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.ExchangeRate)
            .HasColumnType("decimal(19,8)")
            .HasDefaultValue(1m)
            .IsRequired();

        builder.Property(e => e.FunctionalTaxAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.TaxReturnPeriodId)
            .HasColumnType("char(36)");

        builder.Property(e => e.JournalEntryId)
            .HasColumnType("char(36)");

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(TaxTransactionStatus.Open)
            .IsRequired();

        builder.Property(e => e.Notes)
            .HasMaxLength(500);

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TaxCode)
            .WithMany()
            .HasForeignKey(e => e.TaxCodeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TaxRate)
            .WithMany()
            .HasForeignKey(e => e.TaxRateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.FiscalPeriodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
