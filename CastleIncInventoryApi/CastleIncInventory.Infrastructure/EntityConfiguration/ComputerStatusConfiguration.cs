using CastleIncInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastleIncInventory.Infrastructure.EntityConfiguration
{
    internal class ComputerStatusConfiguration : IEntityTypeConfiguration<ComputerStatus>
    {
        public void Configure(EntityTypeBuilder<ComputerStatus> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id);
            entity.Property(e => e.LocalizedName)
                .HasConversion(e => e.ToString(), e => (OperationalStatus)Enum.Parse(typeof(OperationalStatus), e));
        }
    }
}
