using CastleIncInventory.Domain.Entities;

namespace CastleIncInventory.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        User Get(uint id);
    }
}
