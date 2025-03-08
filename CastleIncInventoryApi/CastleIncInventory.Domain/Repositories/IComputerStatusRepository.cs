using CastleIncInventory.Domain.Entities;

namespace CastleIncInventory.Domain.Repositories
{
    public interface IComputerStatusRepository
    {
        Task<bool> IsStatusAlreadyAdded(uint computerId, OperacionalStatus operacionalStatus);

        Task<uint> GetStatusId(OperacionalStatus operacionalStatus);

        void AddStatus(LinkComputerStatus status);
    }
}