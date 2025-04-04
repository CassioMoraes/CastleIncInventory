using CastleIncInventory.Domain.Entities;
using CastleIncInventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CastleIncInventory.Infrastructure.Repositories
{
    public class ComputerRepository : IComputerRepository
    {
        private readonly CastleIncInventoryDbContext _context;

        public ComputerRepository(CastleIncInventoryDbContext context) => _context = context;

        public async Task<IEnumerable<Computer>> GetAllAsync()
        {
            return await _context.Computers
                .Include(c => c.Manufacturer)
                .Include(c => c.ComputerStatuses)
                    .ThenInclude(s => s.ComputerStatus)
                .Include(c => c.ComputerUser)
                    .ThenInclude(u => u.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public Computer Get(int id)
        {
            return _context.Computers.First(c => c.Id == id);
        }

        public Computer Upsert(Computer computer)
        {
            Computer? upsertedComputer = null;

            try
            {
                if (computer.Id == 0)
                    upsertedComputer = _context.Computers.Add(computer).Entity;
                else
                    upsertedComputer = _context.Computers.Update(computer).Entity;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return upsertedComputer;
        }

        public void Delete(int computerId)
        {
            var computer = _context.Computers
                .Include(c => c.ComputerStatuses)
                    .ThenInclude(s => s.ComputerStatus)
                .Include(c => c.ComputerUser)
                .FirstOrDefault(c => c.Id == computerId);

            if (computer is not null)
            {
                _context.Computers.Remove(computer);
                _context.SaveChanges();
            }            
        }
    }
}
