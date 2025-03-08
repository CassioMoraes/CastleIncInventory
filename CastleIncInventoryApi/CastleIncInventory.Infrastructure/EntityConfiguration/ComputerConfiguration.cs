using CastleIncInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastleIncInventory.Infrastructure.EntityConfiguration
{
    internal class ComputerConfiguration : IEntityTypeConfiguration<Computer>
    {
        public void Configure(EntityTypeBuilder<Computer> entity)
        {
            entity.ToTable("computer");

            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Manufacturer).WithMany(e => e.Computers).HasForeignKey(e => e.ComputerManufacturerId);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComputerManufacturerId).HasColumnName("computer_manufacturer_id");
            entity.Property(e => e.SerialNumber).HasColumnName("serial_number");
            entity.Property(e => e.Specifications).HasColumnName("specifications");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_dt");
            entity.Property(e => e.WarrantyExpirationDate).HasColumnName("warranty_expiration_dt");
            entity.Property(e => e.CreateDate).HasColumnName("create_dt");
        }
    }
}
