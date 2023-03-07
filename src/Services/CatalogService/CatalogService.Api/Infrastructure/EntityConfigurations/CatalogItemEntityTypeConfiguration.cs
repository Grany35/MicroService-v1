using CatalogService.Api.Core.Domain;
using CatalogService.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Api.Infrastructure.EntityConfigurations;

public class CatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        builder.ToTable(nameof(CatalogItem), CatalogContext.DEFAULT_SCHEMA);

        builder.Property(k => k.Id).UseHiLo("catalog_hilo").IsRequired();

        builder.Property(k => k.Name).IsRequired().HasMaxLength(50);

        builder.Property(k => k.Price).IsRequired();

        builder.Property(k => k.PictureFileName).IsRequired(false);

        builder.Ignore(k => k.PictureUri);

        builder.HasOne(k => k.CatalogBrand).WithMany().HasForeignKey(f => f.CatalogBrandId);
        
        builder.HasOne(k => k.CatalogType).WithMany().HasForeignKey(f => f.CatalogTypeId);
    }
}