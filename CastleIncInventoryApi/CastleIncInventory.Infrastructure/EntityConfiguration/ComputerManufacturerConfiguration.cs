using CastleIncInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastleIncInventory.Infrastructure.EntityConfiguration
{
    internal class ComputerManufacturerConfiguration : IEntityTypeConfiguration<ComputerManufacturer>
    {
        public void Configure(EntityTypeBuilder<ComputerManufacturer> entity)
        {
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id);
            entity.Property(e => e.Name)
                .HasConversion(e => e.ToString(), e => (Manufactures)Enum.Parse(typeof(Manufactures), e));
            entity.Property(e => e.SerialRegex);
        }
    }
}
