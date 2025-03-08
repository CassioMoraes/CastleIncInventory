using CastleIncInventory.Domain.Entities;
using CastleIncInventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CastleIncInventory.Infrastructure.Repositories
{
    public class ComputerStatusRepository : IComputerStatusRepository
    {
        private readonly CastleIncInventoryContext _context;
        public ComputerStatusRepository(CastleIncInventoryContext context)
        {
            _context = context;
        }

        public async Task<uint> GetStatusId(OperacionalStatus operacionalStatus)
        {
            var statuses = await _context.ComputerStatuses.ToListAsync();
            return statuses.First(s => s.LocalizedName == operacionalStatus).Id;
        }

        public async Task<bool> IsStatusAlreadyAdded(uint computerId, OperacionalStatus operacionalStatus)
        {
            var computerStatuses = await _context.LinkComputerStatuses
                .Include(l => l.ComputerStatus)
                .ToListAsync();

            return computerStatuses.Any(s => s.ComputerId == computerId && s.ComputerStatus.LocalizedName == operacionalStatus);
        }

        public void AddStatus(LinkComputerStatus status)
        {
            _context.LinkComputerStatuses.Add(status);
            _context.SaveChanges();
        }
    }
}
