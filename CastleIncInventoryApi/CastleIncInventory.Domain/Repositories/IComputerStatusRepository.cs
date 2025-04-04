using CastleIncInventory.Domain.Entities;

namespace CastleIncInventory.Domain.Repositories
{
    public interface IComputerStatusRepository
    {
        Task<bool> IsStatusAlreadyAdded(uint computerId, OperationalStatus operacionalStatus);

        Task<uint> GetStatusId(OperationalStatus operacionalStatus);

        void AddStatus(LinkComputerStatus status);
    }
}