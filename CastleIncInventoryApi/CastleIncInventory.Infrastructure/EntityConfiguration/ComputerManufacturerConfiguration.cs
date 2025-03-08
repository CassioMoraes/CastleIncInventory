using CastleIncInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastleIncInventory.Infrastructure.EntityConfiguration
{
    internal class ComputerManufacturerConfiguration : IEntityTypeConfiguration<ComputerManufacturer>
    {
        public void Configure(EntityTypeBuilder<ComputerManufacturer> entity)
        {
            entity.ToTable("computer_manufacturer");

            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name")
                .HasConversion(e => e.ToString(), e => (Manufactures)Enum.Parse(typeof(Manufactures), e));
            entity.Property(e => e.SerialRegex).HasColumnName("serial_regex");
        }
    }
}
