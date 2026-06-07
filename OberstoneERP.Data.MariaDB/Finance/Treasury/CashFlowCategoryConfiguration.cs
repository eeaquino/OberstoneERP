namespace OberstoneERP.Data.MariaDB.Finance.Treasury;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Treasury;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for CashFlowCategory.
/// </summary>
public class CashFlowCategoryConfiguration : BaseEntityConfiguration<CashFlowCategory>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CashFlowCategory> builder)
    {
        builder.ToTable("CashFlowCategories");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_CashFlowCategories_CompanyId");

        builder.Property(e => e.ParentCategoryId)
            .HasColumnType("char(36)");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_CashFlowCategories_CompanyId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.ActivityType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Direction)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Level)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.SortOrder)
            .HasDefaultValue(0)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ParentCategory)
            .WithMany(cfc => cfc.ChildCategories)
            .HasForeignKey(e => e.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
