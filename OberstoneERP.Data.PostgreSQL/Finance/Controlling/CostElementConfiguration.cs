namespace OberstoneERP.Data.PostgreSQL.Finance.Controlling;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Controlling;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for CostElement.
/// </summary>
public class CostElementConfiguration : BaseEntityConfiguration<CostElement>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CostElement> builder)
    {
        builder.ToTable("CostElements", "controlling");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_CostElements_CompanyId");

        builder.Property(e => e.ParentCostElementId)
            .HasColumnType("uuid");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_CostElements_CompanyId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.Category)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.CostElementType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.LinkedAccountId)
            .HasColumnType("uuid");

        builder.Property(e => e.Level)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.HierarchyPath)
            .HasMaxLength(500);

        builder.Property(e => e.ValidFrom)
            .HasColumnType("timestamp with time zone");

        builder.Property(e => e.ValidTo)
            .HasColumnType("timestamp with time zone");

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

                builder.HasOne(e => e.ParentCostElement)
                    .WithMany(ce => ce.ChildCostElements)
                    .HasForeignKey(e => e.ParentCostElementId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
