namespace OberstoneERP.Data.MSSQL.Finance.Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.MSSQL.Extensions;

/// <summary>
/// Base configuration class for all entities that inherit from BaseEntity.
/// Provides common configuration for audit fields, tenant isolation, and UUID v7 generation.
/// </summary>
/// <typeparam name="TEntity">The entity type that inherits from BaseEntity.</typeparam>
public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    /// <summary>
    /// Configures the entity with common settings for BaseEntity properties.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // Primary key with UUID v7 generation
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnType("uniqueidentifier")
            .HasValueGenerator<UuidV7ValueGenerator>()
            .ValueGeneratedOnAdd();

        // Tenant isolation - all queries should filter by tenant
        builder.Property(e => e.TenantId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.TenantId)
            .HasDatabaseName($"IX_{typeof(TEntity).Name}_TenantId");

        // Audit fields
        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(e => e.CreatedBy)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.ModifiedAt)
            .HasColumnType("datetime2");

        builder.Property(e => e.ModifiedBy)
            .HasColumnType("uniqueidentifier");

        // Soft delete
        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.DeletedAt)
            .HasColumnType("datetime2");

        builder.Property(e => e.DeletedBy)
            .HasColumnType("uniqueidentifier");

        // Global query filter for soft delete
        builder.HasQueryFilter(e => !e.IsDeleted);

        // Apply entity-specific configuration
        ConfigureEntity(builder);
    }

    /// <summary>
    /// Override this method to apply entity-specific configuration.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
}
