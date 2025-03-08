using CastleIncInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastleIncInventory.Infrastructure.EntityConfiguration
{
    internal class LinkComputerUserConfiguration : IEntityTypeConfiguration<LinkComputerUser>
    {
        public void Configure(EntityTypeBuilder<LinkComputerUser> entity)
        {
            entity.ToTable("lnk_computer_user");

            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Computer).WithOne(e => e.ComputerUser).HasForeignKey<LinkComputerUser>(e => e.ComputerId);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ComputerId).HasColumnName("computer_id");
            entity.Property(e => e.AssignDate).HasColumnName("assign_start_dt");
            entity.Property(e => e.AssignEndDate).HasColumnName("assign_end_dt");
        }
    }
}
