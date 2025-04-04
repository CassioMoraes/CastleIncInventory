using CastleIncInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastleIncInventory.Infrastructure.EntityConfiguration
{
    internal class ComputerConfiguration : IEntityTypeConfiguration<Computer>
    {
        public void Configure(EntityTypeBuilder<Computer> entity)
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Manufacturer).WithMany(e => e.Computers).HasForeignKey(e => e.ComputerManufacturerId);

            entity.Property(e => e.Id);
            entity.Property(e => e.ComputerManufacturerId);
            entity.Property(e => e.SerialNumber);
            entity.Property(e => e.Specifications);
            entity.Property(e => e.ImageUrl);
            entity.Property(e => e.PurchaseDate);
            entity.Property(e => e.WarrantyExpirationDate);
            entity.Property(e => e.CreateDate);
        }
    }
}
