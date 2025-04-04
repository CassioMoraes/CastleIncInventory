using CastleIncInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastleIncInventory.Infrastructure.EntityConfiguration
{
    internal class LinkComputerStatusConfiguration : IEntityTypeConfiguration<LinkComputerStatus>
    {
        public void Configure(EntityTypeBuilder<LinkComputerStatus> entity)
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Computer).WithMany(e => e.ComputerStatuses).HasForeignKey(e => e.ComputerId);
            entity.HasOne(e => e.ComputerStatus).WithMany(e => e.ComputerLink).HasForeignKey(e => e.ComputerStatusId);

            entity.Property(e => e.Id);
            entity.Property(e => e.ComputerId);
            entity.Property(e => e.ComputerStatusId);
            entity.Property(e => e.AssignDate);
        }
    }
}
