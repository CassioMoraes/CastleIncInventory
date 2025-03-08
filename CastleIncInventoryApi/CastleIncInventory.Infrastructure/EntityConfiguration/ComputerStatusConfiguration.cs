using CastleIncInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastleIncInventory.Infrastructure.EntityConfiguration
{
    internal class ComputerStatusConfiguration : IEntityTypeConfiguration<ComputerStatus>
    {
        public void Configure(EntityTypeBuilder<ComputerStatus> entity)
        {
            entity.ToTable("computer_status");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LocalizedName)
                .HasColumnName("localized_name")
                .HasConversion(e => e.ToString(), e => EnumConverter(e));
        }

        private static OperacionalStatus EnumConverter(string state)
        {
            switch (state)
            {
                case "new":
                    return OperacionalStatus.New;
                case "in_use":
                    return OperacionalStatus.InUse;
                case "available":
                    return OperacionalStatus.Available;
                case "in_maintenance":
                    return OperacionalStatus.InMaintance;
                default:
                    return OperacionalStatus.Retired;
            }
        }
    }
}
