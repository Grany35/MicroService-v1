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

        builder.HasKey(k => k.Id);

        builder.Property(k => k.Name).IsRequired().HasMaxLength(50);

        builder.Property(k => k.Price).IsRequired();

        builder.Property(k => k.Description);

        builder.Property(k => k.PictureFileName).IsRequired(false);

        builder.Ignore(k => k.PictureUri);

        builder.Property(k => k.AvailableStock);

        builder.HasData(
            new()
            {Id = 1,
                CatalogTypeId = 2, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Bot Black Hoodie",
                Name = ".NET Bot Black Hoodie", Price = 19.5M, PictureFileName = "1.png"
            },
            new()
            {Id = 2,
                CatalogTypeId = 1, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Black & White Mug",
                Name = ".NET Black & White Mug", Price = 8.50M, PictureFileName = "2.png"
            },
            new()
            {Id = 3,
                CatalogTypeId = 2, CatalogBrandId = 5, AvailableStock = 100, Description = "Prism White T-Shirt",
                Name = "Prism White T-Shirt", Price = 12, PictureFileName = "3.png"
            },
            new()
            {Id = 4,
                CatalogTypeId = 2, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Foundation T-shirt",
                Name = ".NET Foundation T-shirt", Price = 12, PictureFileName = "4.png"
            },
            new()
            {Id = 5,
                CatalogTypeId = 3, CatalogBrandId = 5, AvailableStock = 100, Description = "Roslyn Red Sheet",
                Name = "Roslyn Red Sheet", Price = 8.5M, PictureFileName = "5.png"
            },
            new()
            {Id = 6,
                CatalogTypeId = 2, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Blue Hoodie",
                Name = ".NET Blue Hoodie", Price = 12, PictureFileName = "6.png"
            },
            new()
            {Id = 7,
                CatalogTypeId = 2, CatalogBrandId = 5, AvailableStock = 100, Description = "Roslyn Red T-Shirt",
                Name = "Roslyn Red T-Shirt", Price = 12, PictureFileName = "7.png"
            },
            new()
            {Id = 8,
                CatalogTypeId = 2, CatalogBrandId = 5, AvailableStock = 100, Description = "Kudu Purple Hoodie",
                Name = "Kudu Purple Hoodie", Price = 8.5M, PictureFileName = "8.png"
            },
            new()
            {Id = 9,
                CatalogTypeId = 1, CatalogBrandId = 5, AvailableStock = 100, Description = "Cup<T> White Mug",
                Name = "Cup<T> White Mug", Price = 12, PictureFileName = "9.png"
            },
            new()
            {Id = 10,
                CatalogTypeId = 3, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Foundation Sheet",
                Name = ".NET Foundation Sheet", Price = 12, PictureFileName = "10.png"
            });

        builder.HasOne(k => k.CatalogBrand).WithMany().HasForeignKey(f => f.CatalogBrandId);

        builder.HasOne(k => k.CatalogType).WithMany().HasForeignKey(f => f.CatalogTypeId);
    }
}