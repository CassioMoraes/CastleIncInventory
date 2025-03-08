using CastleIncInventory.Domain.Entities;
using CastleIncInventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CastleIncInventory.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CastleIncInventoryContext _context;

        public UserRepository(CastleIncInventoryContext context)
        {
            _context = context;
        }

        public User Get(uint id)
        {
            return _context.Users.First(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
