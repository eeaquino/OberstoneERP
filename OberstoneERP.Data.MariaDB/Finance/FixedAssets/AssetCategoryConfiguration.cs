namespace OberstoneERP.Data.MariaDB.Finance.FixedAssets;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.FixedAssets;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for AssetCategory.
/// </summary>
public class AssetCategoryConfiguration : BaseEntityConfiguration<AssetCategory>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<AssetCategory> builder)
    {
        builder.ToTable("AssetCategories");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_AssetCategories_CompanyId");

        builder.Property(e => e.ParentCategoryId)
            .HasColumnType("char(36)");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_AssetCategories_CompanyId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.DefaultUsefulLifeMonths)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.DefaultSalvageValuePercent)
            .HasColumnType("decimal(5,2)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.DefaultDepreciationMethodId)
            .HasColumnType("char(36)");

        builder.Property(e => e.AssetAccountId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.AccumulatedDepreciationAccountId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.DepreciationExpenseAccountId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(e => e.GainOnDisposalAccountId)
            .HasColumnType("char(36)");

        builder.Property(e => e.LossOnDisposalAccountId)
            .HasColumnType("char(36)");

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ParentCategory)
            .WithMany(ac => ac.ChildCategories)
            .HasForeignKey(e => e.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.DefaultDepreciationMethod)
            .WithMany(dm => dm.AssetCategories)
            .HasForeignKey(e => e.DefaultDepreciationMethodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AssetAccount)
            .WithMany()
            .HasForeignKey(e => e.AssetAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AccumulatedDepreciationAccount)
            .WithMany()
            .HasForeignKey(e => e.AccumulatedDepreciationAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.DepreciationExpenseAccount)
            .WithMany()
            .HasForeignKey(e => e.DepreciationExpenseAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
