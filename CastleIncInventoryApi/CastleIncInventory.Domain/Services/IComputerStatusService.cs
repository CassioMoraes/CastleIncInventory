using CastleIncInventory.Domain.Entities;
using CastleIncInventory.Shared;

namespace CastleIncInventory.Domain.Services
{
    public interface IComputerStatusService
    {
        Task<Result> AddStatus(Computer computer, string status);
    }
}
