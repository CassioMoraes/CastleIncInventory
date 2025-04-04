using CastleIncInventory.Domain.Entities;
using CastleIncInventory.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CastleIncInventory.Domain.Repositories
{
    public class ComputerManufacturerRepository : IComputerManufacturerRepository
    {
        private readonly CastleIncInventoryDbContext _context;

        public ComputerManufacturerRepository(CastleIncInventoryDbContext context)
        {
            _context = context;
        }

        public ComputerManufacturer Get(uint id)
        {
            return _context.ComputerManufacturers.FirstOrDefault(x => x.Id == id);
        }

        public ComputerManufacturer GetByName(string name)
        {
            var computerManufacturer = new ComputerManufacturer();

            try
            {
                var manufacturers = _context.ComputerManufacturers.AsNoTracking().ToList();
                computerManufacturer = manufacturers.FirstOrDefault(x => x.Name.ToString().Equals(name));
            }
            catch (Exception ex)
            {

                throw;
            }

            return computerManufacturer;
        }

        public async Task<IEnumerable<ComputerManufacturer>> GetAllAsync()
        {
            return await _context.ComputerManufacturers.ToListAsync();
        }
    }
}
