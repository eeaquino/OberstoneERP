namespace OberstoneERP.Data.PostgreSQL.Finance.Intercompany;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Intercompany;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for IntercompanyAgreement.
/// </summary>
public class IntercompanyAgreementConfiguration : BaseEntityConfiguration<IntercompanyAgreement>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<IntercompanyAgreement> builder)
    {
        builder.ToTable("IntercompanyAgreements", "intercompany");

        builder.Property(e => e.SourceCompanyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.SourceCompanyId)
            .HasDatabaseName("IX_IntercompanyAgreements_SourceCompanyId");

        builder.Property(e => e.TargetCompanyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.TargetCompanyId)
            .HasDatabaseName("IX_IntercompanyAgreements_TargetCompanyId");

        builder.Property(e => e.AgreementNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.TenantId, e.AgreementNumber })
            .IsUnique()
            .HasDatabaseName("IX_IntercompanyAgreements_TenantId_AgreementNumber");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.AgreementType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.EffectiveFrom)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(e => e.EffectiveTo)
            .HasColumnType("timestamp with time zone");

        builder.Property(e => e.CurrencyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(e => e.SourceReceivableAccountId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(e => e.TargetPayableAccountId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(e => e.SourceRevenueAccountId)
            .HasColumnType("uuid");

        builder.Property(e => e.TargetExpenseAccountId)
            .HasColumnType("uuid");

        builder.Property(e => e.MarkupPercent)
            .HasColumnType("decimal(5,2)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(IntercompanyAgreementStatus.Active)
            .IsRequired();

        builder.Property(e => e.AutoCreateElimination)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.Notes)
            .HasMaxLength(1000);

        // Navigation properties
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

        builder.HasOne(e => e.SourceReceivableAccount)
            .WithMany()
            .HasForeignKey(e => e.SourceReceivableAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TargetPayableAccount)
            .WithMany()
            .HasForeignKey(e => e.TargetPayableAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
