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

        builder.Property(k => k.Brand)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(new() { Id = 1,Brand = "Azure" },
            new() { Id = 2,Brand = ".NET" },
            new() {Id = 3, Brand = "Visual Studio" },
            new() { Id = 4,Brand = "SQL Server" },
            new() { Id = 5,Brand = "Other" });
    }
}