using CastleIncInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastleIncInventory.Infrastructure.EntityConfiguration
{
    internal class LinkComputerUserConfiguration : IEntityTypeConfiguration<LinkComputerUser>
    {
        public void Configure(EntityTypeBuilder<LinkComputerUser> entity)
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Computer).WithOne(e => e.ComputerUser).HasForeignKey<LinkComputerUser>(e => e.ComputerId);

            entity.Property(e => e.Id);
            entity.Property(e => e.UserId);
            entity.Property(e => e.ComputerId);
            entity.Property(e => e.AssignDate);
            entity.Property(e => e.AssignEndDate);
        }
    }
}
