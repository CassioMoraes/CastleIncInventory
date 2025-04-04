using CastleIncInventory.Domain.Entities;
using CastleIncInventory.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace CastleIncInventory.Infrastructure
{
    public class CastleIncInventoryDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Computer> Computers { get; set; }
        public DbSet<ComputerManufacturer> ComputerManufacturers { get; set; }
        public DbSet<ComputerStatus> ComputerStatuses { get; set; }
        public DbSet<LinkComputerStatus> LinkComputerStatuses { get; set; }
        public DbSet<LinkComputerUser> LinkComputerUsers { get; set; }
        public DbSet<User> Users { get; set; }

        public CastleIncInventoryDbContext(IConfiguration configuration) { _configuration = configuration; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ComputerConfiguration());
            modelBuilder.ApplyConfiguration(new ComputerManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new ComputerStatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new LinkComputerStatusConfiguration());
            modelBuilder.ApplyConfiguration(new LinkComputerUserConfiguration());
        }
    }
}
