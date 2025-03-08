using CastleIncInventory.Domain.Entities;

namespace CastleIncInventory.Domain.Repositories
{
    public interface IComputerManufacturerRepository
    {
        Task<IEnumerable<ComputerManufacturer>> GetAllAsync();

        ComputerManufacturer Get(uint id);

        ComputerManufacturer GetByName(string name);
    }
}
