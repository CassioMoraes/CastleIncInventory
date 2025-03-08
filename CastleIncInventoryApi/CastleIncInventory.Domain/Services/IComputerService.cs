using CastleIncInventory.Domain.DataTransfer;
using CastleIncInventory.Shared;

namespace CastleIncInventory.Domain.Services
{
    public interface IComputerService
    {
        Task<Result> Upsert(ComputerUpsert computer);
        Task<IEnumerable<ComputerUpsert>> GetAll();
        void Delete(int computerId);
    }
}
