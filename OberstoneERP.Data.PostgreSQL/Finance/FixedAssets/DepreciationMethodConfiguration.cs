namespace OberstoneERP.Data.PostgreSQL.Finance.FixedAssets;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.FixedAssets;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for DepreciationMethod.
/// </summary>
public class DepreciationMethodConfiguration : BaseEntityConfiguration<DepreciationMethod>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<DepreciationMethod> builder)
    {
        builder.ToTable("DepreciationMethods", "fixedassets");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.TenantId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_DepreciationMethods_TenantId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.DepreciationType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();
    }
}
