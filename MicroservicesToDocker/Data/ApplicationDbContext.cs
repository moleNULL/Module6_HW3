#pragma warning disable CS8618
using MicroservicesToDocker.Data.Entities;
using MicroservicesToDocker.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesToDocker.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CatalogItemEntity> CatalogItems { get; set; }
    public DbSet<CatalogBrandEntity> CatalogBrands { get; set; }
    public DbSet<CatalogTypeEntity> CatalogTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
        builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
        builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
    }
}
