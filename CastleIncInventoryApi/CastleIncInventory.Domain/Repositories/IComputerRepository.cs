using CastleIncInventory.Domain.Entities;

namespace CastleIncInventory.Domain.Repositories
{
    public interface IComputerRepository
    {
        Task<IEnumerable<Computer>> GetAllAsync();
        Computer Get(int id);
        Computer Upsert(Computer computer);
        void Delete(int computerId);
    }
}
