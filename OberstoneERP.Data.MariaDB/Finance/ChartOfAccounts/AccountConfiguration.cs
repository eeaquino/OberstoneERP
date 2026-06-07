namespace OberstoneERP.Data.MariaDB.Finance.ChartOfAccounts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for Account.
/// </summary>
public class AccountConfiguration : BaseEntityConfiguration<Account>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_Accounts_CompanyId");

        builder.Property(e => e.AccountTypeId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.AccountGroupId)
            .HasColumnType("char(36)");

        builder.Property(e => e.AccountNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.AccountNumber })
            .IsUnique()
            .HasDatabaseName("IX_Accounts_CompanyId_AccountNumber");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.CurrencyId)
            .HasColumnType("char(36)");

        builder.Property(e => e.IsPostingAllowed)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.IsControlAccount)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.ControlAccountType)
            .HasConversion<int?>();

        builder.Property(e => e.RequiresCostCenter)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.RequiresProfitCenter)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.IsBankAccount)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.IsCashAccount)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.Balance)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.OpenedDate)
            .HasColumnType("datetime(6)");

        builder.Property(e => e.ClosedDate)
            .HasColumnType("datetime(6)");

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AccountType)
            .WithMany(at => at.Accounts)
            .HasForeignKey(e => e.AccountTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AccountGroup)
            .WithMany(ag => ag.Accounts)
            .HasForeignKey(e => e.AccountGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
