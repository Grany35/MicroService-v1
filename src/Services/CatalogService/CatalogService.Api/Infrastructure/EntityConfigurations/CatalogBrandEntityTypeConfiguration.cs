using CatalogService.Api.Core.Domain;
using CatalogService.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Api.Infrastructure.EntityConfigurations;

public class CatalogBrandEntityTypeConfiguration : IEntityTypeConfiguration<CatalogBrand>

{
    public void Configure(EntityTypeBuilder<CatalogBrand> builder)
    {
        builder.ToTable(nameof(CatalogBrand), CatalogContext.DEFAULT_SCHEMA);

        builder.HasKey(k => k.Id);

        builder.Property(k => k.Id)
            .UseHiLo("catalog_brand_hilo")
            .IsRequired();

        builder.Property(k => k.Brand)
            .IsRequired()
            .HasMaxLength(100);
    }
}