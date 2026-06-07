namespace OberstoneERP.Data.MariaDB.Finance.Treasury;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Treasury;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for BankAccount.
/// </summary>
public class BankAccountConfiguration : BaseEntityConfiguration<BankAccount>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<BankAccount> builder)
    {
        builder.ToTable("BankAccounts");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_BankAccounts_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("char(36)");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_BankAccounts_CompanyId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.BankName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.BranchName)
            .HasMaxLength(200);

        builder.Property(e => e.AccountNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.IBAN)
            .HasMaxLength(50);

        builder.Property(e => e.SwiftCode)
            .HasMaxLength(20);

        builder.Property(e => e.RoutingNumber)
            .HasMaxLength(50);

        builder.Property(e => e.AccountType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.CurrencyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.GLAccountId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.BookBalance)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.StatementBalance)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.LastStatementDate)
            .HasColumnType("datetime(6)");

        builder.Property(e => e.LastReconciliationDate)
            .HasColumnType("datetime(6)");

        builder.Property(e => e.MinimumBalance)
            .HasColumnType("decimal(19,4)");

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Site)
            .WithMany()
            .HasForeignKey(e => e.SiteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.GLAccount)
            .WithMany()
            .HasForeignKey(e => e.GLAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
